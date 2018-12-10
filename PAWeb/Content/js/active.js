(function ($) {
    'use strict';

    var browserWindow = $(window);


    browserWindow.on('load', function () {
        $('.preloader').fadeOut('slow', function () {
            $(this).remove();
        });
    });

    //$('[data-countdown]').each(function () {
    //   var $this = $(this),
    //       finalDate = $(this).data('countdown');
    //   $this.countdown(finalDate, function (event) {
    //       $this.html(event.strftime('%D <span>Days</span> %H <span>Hours</span> %M <span>Minutes</span> %S <span>Seconds</span>'));
    //    });
    //});




  
  
    if ($.fn.classyNav) {
        $('#croseNav').classyNav();
    }

 
    $('#header-search').on('click', function () {
        $('.search-form-area').toggleClass('search-on');
    });
    $('#searchCloseIcon').on('click', function () {
        $('.search-form-area').removeClass('search-on');
    });

  
    if ($.fn.owlCarousel) {
        var welcomeSlide = $('.hero-post-slides');
        var upcomingSlides = $('.upcoming-slides');

        welcomeSlide.owlCarousel({
            items: 1,
            margin: 0,
            loop: true,
            nav: false,
            dots: false,
            autoplay: true,
            center: true,
            autoplayTimeout: 7000,
            smartSpeed: 1000
        });

        welcomeSlide.on('translate.owl.carousel', function () {
            var slideLayer = $("[data-animation]");
            slideLayer.each(function () {
                var anim_name = $(this).data('animation');
                $(this).removeClass('animated ' + anim_name).css('opacity', '0');
            });
        });

        welcomeSlide.on('translated.owl.carousel', function () {
            var slideLayer = welcomeSlide.find('.owl-item.active').find("[data-animation]");
            slideLayer.each(function () {
                var anim_name = $(this).data('animation');
                $(this).addClass('animated ' + anim_name).css('opacity', '1');
            });
        });

        $("[data-delay]").each(function () {
            var anim_del = $(this).data('delay');
            $(this).css('animation-delay', anim_del);
        });

        $("[data-duration]").each(function () {
            var anim_dur = $(this).data('duration');
            $(this).css('animation-duration', anim_dur);
        });

        upcomingSlides.owlCarousel({
            items: 1,
            margin: 0,
            loop: true,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            dots: false,
            autoplay: true,
            autoplayTimeout: 7000,
            smartSpeed: 1500
        });
    }
    
   
    if ($.fn.magnificPopup) {
        $('.gallery-img').magnificPopup({
            gallery: {
                enabled: true
            },
            type: 'image'
        });
    }
    
   
    if ($.fn.scrollUp) {
        browserWindow.scrollUp({
            scrollSpeed: 1500,
            scrollText: '<i class="fa fa-angle-up"></i>'
        });
    }

  
    if ($.fn.sticky) {
        $(".crose-main-menu").sticky({
            topSpacing: 0
        });
    }

    
    if ($.fn.tooltip) {
        $('[data-toggle="tooltip"]').tooltip()
    }

    $('a[href="#"]').on('click', function ($) {
        $.preventDefault();
    });

    if (browserWindow.width() > 767) {
        new WOW().init();
    }

})(jQuery);