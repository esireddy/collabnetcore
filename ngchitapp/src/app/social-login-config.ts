import { AuthServiceConfig, GoogleLoginProvider } from 'angularx-social-login';

export function getAuthServiceConfigs() {
    const config = new AuthServiceConfig([{
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider('581732818292-85l23etacnc3888l5idkrrf141hptdcg.apps.googleusercontent.com')
    }]);

    return config;
}
