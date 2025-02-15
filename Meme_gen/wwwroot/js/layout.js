//hover function for navbar
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".nav-item.dropdown").forEach(function (dropdown) {
      dropdown.addEventListener("mouseenter", function () {
        dropdown.classList.add("show");
        var menu = dropdown.querySelector(".dropdown-menu");
        if (menu) {
          menu.classList.add("show");
        }
      });
      dropdown.addEventListener("mouseleave", function () {
        dropdown.classList.remove("show");
        var menu = dropdown.querySelector(".dropdown-menu");
        if (menu) {
          menu.classList.remove("show");
        }
      });
    });
});
