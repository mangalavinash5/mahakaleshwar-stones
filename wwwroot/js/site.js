/* ============================================================
   Mahakaleshwar Stones — MAIN JAVASCRIPT
   ============================================================ */

$(function () {
  /* ---- PRELOADER ---- */
  function hidePreloader() {
    var $p = $("#preloader");
    if ($p.hasClass("hidden")) return;
    $p.addClass("hidden");
    setTimeout(function () {
      $p.hide();
    }, 500);
  }
  $(window).on("load", function () {
    setTimeout(hidePreloader, 300);
  });
  setTimeout(hidePreloader, 1500);

  /* ---- STICKY NAVBAR ---- */
  $(window).on("scroll", function () {
    if ($(this).scrollTop() > 60) {
      $("#mainNavbar").addClass("scrolled");
    } else {
      $("#mainNavbar").removeClass("scrolled");
    }

    /* Back to top visibility */
    if ($(this).scrollTop() > 300) {
      $("#backToTop").addClass("visible");
    } else {
      $("#backToTop").removeClass("visible");
    }
  });

  /* ---- BACK TO TOP ---- */
  $("#backToTop").on("click", function () {
    $("html, body").animate({ scrollTop: 0 }, 500);
  });

  /* ---- ACTIVE NAV LINK ---- */
  var path = window.location.pathname.toLowerCase();
  $(".site-navbar .nav-link").each(function () {
    var href = $(this).attr("href") || "";
    if (href && href !== "/" && path.startsWith(href.toLowerCase())) {
      $(this).addClass("active-nav");
      $(this).css("color", "var(--gold)");
    }
  });

  /* ---- COUNTER ANIMATION ---- */
  function animateCounters() {
    $(".stat-item").each(function () {
      var target = parseInt($(this).data("count"));
      var counter = $(this).find(".counter");
      var current = 0;
      var increment = Math.ceil(target / 50);
      var timer = setInterval(function () {
        current += increment;
        if (current >= target) {
          counter.text(target.toLocaleString());
          clearInterval(timer);
        } else {
          counter.text(current.toLocaleString());
        }
      }, 30);
    });
  }

  /* ---- INTERSECTION OBSERVER — fade in sections + trigger counters ---- */
  var statsAnimated = false;
  var observer = new IntersectionObserver(
    function (entries) {
      entries.forEach(function (entry) {
        if (entry.isIntersecting) {
          entry.target.classList.add("visible");
          if (
            entry.target.classList.contains("stats-section") &&
            !statsAnimated
          ) {
            statsAnimated = true;
            animateCounters();
          }
        }
      });
    },
    { threshold: 0.15 },
  );

  document
    .querySelectorAll(".fade-in-section, .stats-section")
    .forEach(function (el) {
      observer.observe(el);
    });

  /* Auto-add fade-in-section to major sections */
  document
    .querySelectorAll(
      ".about-section, .categories-section, .products-section, .why-section, .export-section, .projects-section, .testimonials-section, .faq-preview-section, .inquiry-section",
    )
    .forEach(function (el) {
      el.classList.add("fade-in-section");
      observer.observe(el);
    });

  /* ---- INQUIRY MODAL FORM SUBMIT ---- */
  $("#inquiryForm").on("submit", function (e) {
    e.preventDefault();
    var btn = $("#inquirySubmitBtn");
    btn.find(".submit-text").addClass("d-none");
    btn.find(".submit-loading").removeClass("d-none");
    btn.prop("disabled", true);

    $.ajax({
      url: "/Inquiry/Submit",
      method: "POST",
      data: $(this).serialize(),
      success: function (res) {
        if (res.success) {
          $("#inquiryForm")[0].reset();
          var modal = bootstrap.Modal.getInstance(
            document.getElementById("inquiryModal"),
          );
          if (modal) modal.hide();
          showToast(res.message, "success");
        } else {
          showToast(res.message, "danger");
        }
      },
      error: function () {
        showToast(
          "Something went wrong. Please try again or contact us via WhatsApp.",
          "danger",
        );
      },
      complete: function () {
        btn.find(".submit-text").removeClass("d-none");
        btn.find(".submit-loading").addClass("d-none");
        btn.prop("disabled", false);
      },
    });
  });

  /* ---- SMOOTH SCROLLING ---- */
  $('a[href^="#"]').on("click", function (e) {
    var target = $($(this).attr("href"));
    if (target.length) {
      e.preventDefault();
      $("html, body").animate({ scrollTop: target.offset().top - 80 }, 600);
    }
  });

  /* ---- LAZY IMAGE LOADING FALLBACK ---- */
  if (!("loading" in HTMLImageElement.prototype)) {
    document.querySelectorAll('img[loading="lazy"]').forEach(function (img) {
      img.src = img.dataset.src || img.src;
    });
  }

  /* ---- TOUCH: product card tap to reveal overlay ---- */
  if ("ontouchstart" in window) {
    $(document).on("touchend", ".product-card", function (e) {
      var overlay = $(this).find(".product-overlay");
      if (parseFloat(overlay.css("opacity")) < 0.5) {
        $(".product-overlay").css("opacity", "0");
        overlay.css("opacity", "1");
        e.preventDefault();
      }
    });
    $(document).on("touchstart", function (e) {
      if (!$(e.target).closest(".product-card").length) {
        $(".product-overlay").css("opacity", "");
      }
    });
  }

  /* ---- SWIPE GALLERY on touch ---- */
  var touchStartX = 0;
  var mainImg = document.getElementById("mainImage");
  if (mainImg) {
    mainImg.addEventListener(
      "touchstart",
      function (e) {
        touchStartX = e.changedTouches[0].clientX;
      },
      { passive: true },
    );
    mainImg.addEventListener(
      "touchend",
      function (e) {
        var dx = e.changedTouches[0].clientX - touchStartX;
        if (Math.abs(dx) < 40) return;
        var thumbs = document.querySelectorAll(".gallery-thumb");
        if (!thumbs.length) return;
        var current = Array.from(thumbs).findIndex(function (t) {
          return t.classList.contains("active");
        });
        var next =
          dx < 0
            ? Math.min(current + 1, thumbs.length - 1)
            : Math.max(current - 1, 0);
        if (next !== current) thumbs[next].click();
      },
      { passive: true },
    );
  }

  /* ---- DRAG SCROLL for horizontal filter tabs on desktop ---- */
  document.querySelectorAll(".project-filter-tabs").forEach(function (el) {
    var isDown = false,
      startX,
      scrollLeft;
    el.addEventListener("mousedown", function (e) {
      isDown = true;
      startX = e.pageX - el.offsetLeft;
      scrollLeft = el.scrollLeft;
    });
    el.addEventListener("mouseleave", function () {
      isDown = false;
    });
    el.addEventListener("mouseup", function () {
      isDown = false;
    });
    el.addEventListener("mousemove", function (e) {
      if (!isDown) return;
      e.preventDefault();
      el.scrollLeft = scrollLeft - (e.pageX - el.offsetLeft - startX);
    });
  });

  /* ---- FORM VALIDATION STYLES ---- */
  $("form input[required], form select[required], form textarea[required]").on(
    "blur",
    function () {
      if (!$(this).val()) {
        $(this).addClass("is-invalid");
      } else {
        $(this).removeClass("is-invalid").addClass("is-valid");
      }
    },
  );
});

/* ---- TOAST HELPER (global) ---- */
function showToast(message, type) {
  type = type || "success";
  var toastEl = document.getElementById("successToast");
  if (toastEl) {
    toastEl.className =
      "toast align-items-center text-white border-0 bg-" + type;
    document.getElementById("toastMessage").textContent = message;
    var toast = new bootstrap.Toast(toastEl, { delay: 5000 });
    toast.show();
  }
}

/* ---- OPEN INQUIRY MODAL WITH PRODUCT NAME ---- */
function openInquiry(productName) {
  var modalProductInput = document.getElementById("modalProductName");
  if (modalProductInput && productName) {
    modalProductInput.value = productName;
  }
  var modal = new bootstrap.Modal(document.getElementById("inquiryModal"));
  modal.show();
}
