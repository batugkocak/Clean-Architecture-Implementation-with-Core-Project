using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.ClaimsExtension;
using Core.Security.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoleClaims == null)
            throw new AuthorizationException("You are not authenticated.");

        // bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleClaims
        //     .FirstOrDefault(
        //         userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin ||
        //                          request.Roles.Any(role => role == userRoleClaim)
        //     ).IsNullOrEmpty();
        string? filteredByRequestUserRoles = userRoleClaims
            .FirstOrDefault(
                userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin ||
                                 request.Roles.Any(role => role == userRoleClaim)
            );
        
        bool isNotMatchedAUserRoleClaimWithRequestRoles = string.IsNullOrEmpty(filteredByRequestUserRoles);
        
        if (isNotMatchedAUserRoleClaimWithRequestRoles)
            throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}