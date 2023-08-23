namespace MVCProjectWeb.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string cookieValue = context.Request.Cookies["YourCookieName"];
            if (!string.IsNullOrEmpty(cookieValue))
            {
                // Process the cookie value and set session-dependent data
                // You can store data in HttpContext.Items for global access
                context.Items["YourSessionData"] = cookieValue;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
