document.addEventListener("DOMContentLoaded", function () {
    var canvasElement = document.getElementById('memeCanvas');
    if (!canvasElement) return;

    var canvas = new fabric.Canvas('memeCanvas');

    // Load custom image from sessionStorage
    var customImageData = sessionStorage.getItem('customMemeImage');
    if (customImageData) {
        fabric.Image.fromURL(customImageData, function (img) {
            canvas.setWidth(img.width);
            canvas.setHeight(img.height);
            canvas.setBackgroundImage(img, canvas.renderAll.bind(canvas));
        });
    } else {
        alert("No custom image found. Please upload an image from the homepage.");
    }

    // Add text button event
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

    // Remove selected textbox event
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

    // Remove all textboxes event
    var removeAllTextBtn = document.getElementById('removeAllTextBtn');
    if (removeAllTextBtn) {
        removeAllTextBtn.addEventListener('click', function () {
            var objects = canvas.getObjects('textbox');
            objects.forEach(function (obj) {
                canvas.remove(obj);
            });
            canvas.renderAll();
        });
    }

    // Save meme (download) event
    var saveMemeBtn = document.getElementById('saveMemeBtn');
    if (saveMemeBtn) {
        saveMemeBtn.addEventListener('click', function () {
            var dataURL = canvas.toDataURL('image/png');
            var link = document.createElement('a');
            link.href = dataURL;
            link.download = 'custom-meme.png';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });
    }

    // Apply fill color event
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

    // Apply stroke (outline) color event
    var strokeColorPicker = document.getElementById('strokeColorPicker');
    var applyStrokeColorBtn = document.getElementById('applyStrokeColorBtn');
    if (applyStrokeColorBtn) {
        applyStrokeColorBtn.addEventListener('click', function () {
            var activeObject = canvas.getActiveObject();
            if (activeObject && activeObject.type === 'textbox') {
                activeObject.set('stroke', strokeColorPicker.value);
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
