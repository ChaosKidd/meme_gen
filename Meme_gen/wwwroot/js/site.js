// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function() {
    const canvas = document.getElementById('memeCanvas');
    const ctx = canvas.getContext('2d');
    const img = new Image();
    
    img.onload = function() {
        canvas.width = img.width;
        canvas.height = img.height;
        ctx.drawImage(img, 0, 0);
    };
    img.src = memeUrl; // Set this variable in your View

    // Like functionality
    $('.like-btn').click(function() {
        const memeId = $(this).data('meme-id');
        $.post('/Meme/Like/' + memeId)
            .done(function(response) {
                if (response.success) {
                    $(this).addClass('liked');
                }
            })
            .fail(function() {
                window.location.href = '/Identity/Account/Login';
            });
    });
});

function addTextBox() {
    const textDiv = document.createElement('div');
    textDiv.contentEditable = true;
    textDiv.className = 'draggable-text';
    document.getElementById('textBoxContainer').appendChild(textDiv);
    
    // Make it draggable (requires jQuery UI)
    $(textDiv).draggable();
}

function saveImage() {
    // Draw all text onto canvas
    const texts = document.getElementsByClassName('draggable-text');
    Array.from(texts).forEach(textDiv => {
        const rect = textDiv.getBoundingClientRect();
        ctx.fillText(textDiv.innerText, rect.left, rect.top);
    });
    
    // Download image
    const link = document.createElement('a');
    link.download = 'meme.png';
    link.href = canvas.toDataURL('image/png');
    link.click();
}