using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Extensions {
    public static class MiddelwareExtension {
        public static WebApplication? AddWebMiddleware(this WebApplication? app) {
            app.UseSwagger();
            app.UseSwaggerUI();
            app?.UseHttpsRedirection();
            app?.UseAuthentication();
            app?.UseAuthorization();
            app?.MapControllers();
            return app;
        }
    }
}
