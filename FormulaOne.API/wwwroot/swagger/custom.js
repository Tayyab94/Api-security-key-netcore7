$(function () {
    var apiKeyInput = $('#input_apiKey');
    var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Apikey", "YOUR_API_KEY", "header");
    
    var bearerInput = $('#input_bearer');
    var bearerAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer YOUR_BEARER_TOKEN", "header");
    
    // Add a single "Authorize" button for both API key and bearer token
    var authBtn = $('<input id="input_auth" type="button" value="Authorize" class="btn btn-success" />');
    
    authBtn.click(function () {
        if (apiKeyInput.val() && bearerInput.val()) {
            apiKeyAuth.apiKey = apiKeyInput.val();
            bearerAuth.apiKey = bearerInput.val();
            
            apiKeyAuth.applyToRequests();
            bearerAuth.applyToRequests();
        }
    });
    
    apiKeyInput.after(authBtn);
});