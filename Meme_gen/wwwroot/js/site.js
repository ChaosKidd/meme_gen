// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener("DOMContentLoaded", function () {
    // Check if we are on a page with the meme canvas.
    var canvasElement = document.getElementById('memeCanvas');
    if (!canvasElement) return; // Nothing to do if no canvas exists

    // Initialize Fabric.js canvas
    var canvas = new fabric.Canvas('memeCanvas');

    // Retrieve meme id and background image path from data attributes
    var memeId = canvasElement.getAttribute('data-meme-id');
    var bgImagePath = canvasElement.getAttribute('data-image-path');

    if (bgImagePath) {
        fabric.Image.fromURL(bgImagePath, function (img) {
            // Set canvas dimensions to the image's natural dimensions
            canvas.setWidth(img.width);
            canvas.setHeight(img.height);
            // Set the background image without scaling (the canvas now matches the image size)
            canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas));
        });
    }

    // Add text button event: creates a draggable textbox
    var addTextBtn = document.getElementById('addTextBtn');
    if (addTextBtn) {
        addTextBtn.addEventListener('click', function () {
            var textbox = new fabric.Textbox('Enter text', {
                left: 100,
                top: 100,
                fontSize: 50,
                fill: '#ffffff',
                stroke: '#000000',
                strokeWidth: 0.75,
                editable: true
            });
            canvas.add(textbox);
            canvas.setActiveObject(textbox);
        });
    }

    // Remove selected textbox button event
    var removeTextBtn = document.getElementById('removeTextBtn');
    if (removeTextBtn) {
        removeTextBtn.addEventListener('click', function () {
            var activeObject = canvas.getActiveObject();
            if (activeObject && activeObject.type === 'textbox') {
                canvas.remove(activeObject);
            } else {
                alert("Please select a textbox to remove.");
            }
        });
    }

    // Remove all textboxes button event
    var removeAllTextBtn = document.getElementById('removeAllTextBtn');
    if (removeAllTextBtn) {
        removeAllTextBtn.addEventListener('click', function () {
            // Get all objects that are textboxes
            var objects = canvas.getObjects('textbox');
            objects.forEach(function (obj) {
                canvas.remove(obj);
            });
            canvas.renderAll();
        });
    }

    // Bookmark button event: toggles bookmark (calls the correct endpoint)
    var bookmarkBtn = document.getElementById('bookmarkBtn');
    if (bookmarkBtn) {
        bookmarkBtn.addEventListener('click', function () {
            fetch('/Meme/ToggleBookmark', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ memeId: parseInt(memeId) })
            })
            .then(response => response.json())
            .then(data => {
                alert(data.message);
                // Optionally update the UI based on data.bookmarked (e.g., change icon color)
                if (data.bookmarked) {
                    bookmarkBtn.classList.add("bookmarked");
                } else {
                    bookmarkBtn.classList.remove("bookmarked");
                }
            })
            .catch(err => console.error(err));
        });
    }

    // Save meme button event: triggers a download of the canvas as an image
    var saveMemeBtn = document.getElementById('saveMemeBtn');
    if (saveMemeBtn) {
        saveMemeBtn.addEventListener('click', function () {
            var dataURL = canvas.toDataURL('image/png');
            var link = document.createElement('a');
            link.href = dataURL;
            link.download = 'meme.png';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });
    }

    // Apply fill color to the selected textbox
    var fillColorPicker = document.getElementById('fillColorPicker');
    var applyFillColorBtn = document.getElementById('applyFillColorBtn');
    if (applyFillColorBtn) {
        applyFillColorBtn.addEventListener('click', function () {
            var activeObject = canvas.getActiveObject();
            if (activeObject && activeObject.type === 'textbox') {
                activeObject.set('fill', fillColorPicker.value);
                canvas.renderAll();
            } else {
                alert("Please select a textbox to change its fill color.");
            }
        });
    }

    // Apply stroke (outline) color to the selected textbox
    var strokeColorPicker = document.getElementById('strokeColorPicker');
    var applyStrokeColorBtn = document.getElementById('applyStrokeColorBtn');
    if (applyStrokeColorBtn) {
        applyStrokeColorBtn.addEventListener('click', function () {
            var activeObject = canvas.getActiveObject();
            if (activeObject && activeObject.type === 'textbox') {
                activeObject.set('stroke', strokeColorPicker.value);
                // Optionally, adjust strokeWidth if needed:
                if (!activeObject.strokeWidth || activeObject.strokeWidth < 1) {
                    activeObject.set('strokeWidth', 1);
                }
                canvas.renderAll();
            } else {
                alert("Please select a textbox to change its outline color.");
            }
        });
    }
});
