// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function transitionAndRedirect() {
    // Remove the fade-out class to trigger the fade-in effect
    const pageContainer = document.getElementById('page-container');
    pageContainer.classList.remove('fade-out');

    // Delay the actual navigation to give time for the fade-in effect
    setTimeout(function () {
        window.location.href = '/Book/ViewOneBook'; // Update with your desired URL
    }, 500); // 500ms matches the duration of the fade-in transition
}