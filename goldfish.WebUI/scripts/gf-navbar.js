/// <reference path="../bower_components/jquery/dist/jquery.min.js" />

(function ($) {
    $.fn.gf_navbar = function (targetElement) {

        this.each(function () {
            var $this = $(this);
            var width = (window.innerWidth > 0) ? window.innerWidth : screen.width;

            var $target = $(targetElement);
            var $wrapper = $this.find('.gf-navbar-wrapper');
            var $menu = $this.find('.gf-navbar');
            var $closeBtn = $wrapper.find('.gf-navbar__close-btn > .fa');

            $closeBtn.click(function () {
                hideNavBar($wrapper, $menu);
            });

            $target.click(function () {
                showNavBar($wrapper, $menu);
            });
        });

        function showNavBar(wrapper, menu) {
            $('body').css('overflow', 'hidden');
            var width = parseInt($(menu).css('width').replace('px',''));
            $(wrapper).css('background-image', 'linear-gradient(to left top, rgba(0,0,0,.3), rgba(0,0,0,.5))').animate({
                'z-index': 8999
            },
                'fast',
                function () {
                    $(menu).animate({
                        'margin-right': '0'
                    }, 'fast', function () {
                        $('body').css({
                            'position': 'absolute',
                            'right': width+30 +'px'
                        });
                    });
                });
        }

        function hideNavBar(wrapper, menu) {
            $('body').css('overflow', 'auto');
            var width = $(menu).css('width');
            $(wrapper).css('background-image', 'none').animate({
                'z-index': -8999
            },
                'fast',
                function () {
                    $(menu).animate({ 'margin-right': '-' + width }, 'fast', function () {
                        $('body').css({
                            'position': 'unset',
                            'right': 0
                        });
                    });
                });
        }
    };
})(jQuery);