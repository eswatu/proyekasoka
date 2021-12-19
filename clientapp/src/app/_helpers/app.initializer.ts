import { AuthenticationService } from '../_services';

export function appInitializer(authenticationService: AuthenticationService) {
    return () => authenticationService.refreshToken().subscribe();
}