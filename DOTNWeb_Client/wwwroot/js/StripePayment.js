redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51MyLLpHvmLwcLdtVW4Q7kOGAzgfmmYzt909FeDrHIT1YQJuUExdUhOS59olZMH8a4cgJnWrUZC4DSvIXymIldyIH00IyOLs1mh");
    stripe.redirectToCheckout({ sessionId: sessionId });
}