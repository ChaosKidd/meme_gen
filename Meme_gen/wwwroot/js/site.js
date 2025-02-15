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

  // Save meme button event: sends the canvas data to the server
  var saveMemeBtn = document.getElementById('saveMemeBtn');
  if (saveMemeBtn) {
    saveMemeBtn.addEventListener('click', function () {
        // Get the image data from the canvas as a base64-encoded PNG
        var dataURL = canvas.toDataURL('image/png');

        // Create a temporary link element
        var link = document.createElement('a');
        link.href = dataURL;
        link.download = 'meme.png'; // The name of the file to be downloaded

        // Append the link, trigger click, and then remove it
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);

    });
  }
});
