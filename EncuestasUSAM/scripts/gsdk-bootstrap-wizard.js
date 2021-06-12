/*!

 =========================================================
 * Bootstrap Wizard - v1.1.1
 =========================================================
 
 * Product Page: https://www.creative-tim.com/product/bootstrap-wizard
 * Copyright 2017 Creative Tim (http://www.creative-tim.com)
 * Licensed under MIT (https://github.com/creativetimofficial/bootstrap-wizard/blob/master/LICENSE.md)
 
 =========================================================
 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 */

// Get Shit Done Kit Bootstrap Wizard Functions

searchVisible = 0;
transparent = true;

$(document).ready(function () {

    var pass1 = $('[name=PASSWORD]');
    var pass2 = $('[name=RePASSWORD]');
    var confirmacion = "Las contrase\361as coinciden";
    var segura = "Contrase\361a segura";
    var insegura = "Contrase\361a insegura";
    var negacion = "Las contrase\361as no coinciden";

    //oculto por defecto el elemento span
    var span1 = $('<span></span>').insertAfter(pass1);
    var span2 = $('<span></span>').insertAfter(pass2);
    span1.hide();
    span2.hide();

    // FUNCION QUE COMPARA LAS CONTRASEÑAS 
    function coincidePassword() {
        var valor1 = pass1.val();
        var valor2 = pass2.val();

        //muestro el span
        span2.show().removeClass();

        //condiciones dentro de la función
        if (valor1 != valor2) {
            span2.text(negacion).addClass('text-danger');
            $('input[type=submit]').attr('disabled', 'disabled');
            $('input[name="finish"]').css({ 'cursor': 'not-allowed' });
        } else if (valor1.length != 0 && valor1 == valor2) {
            span2.text(confirmacion).removeClass('text-danger').addClass('text-success');
            $('input[type=submit]').removeAttr('disabled');
            $('input[type=submit]').css({ 'cursor': 'pointer' });
        }
        if (valor2 == "") {
            span2.hide();
        }
    }

    // FUNCION PARA MENSAJE DE CONTRASEÑA SEGURA
    pass1.keyup(function () {

        var valor1 = pass1.val(); // VARIABLE QUE TOMA EL VALOR DE PASSWORD

        // MOSTRAR MENSAJE
        span1.show().removeClass();

        // CONDICIONES PARA ASIGNAR MENSAJE
        if (valor1.length > 10) {
            span1.text(segura).addClass('text-success');
        } else if (valor1.length <= 10) {
            span1.text(insegura).addClass('text-danger');
        }
        if (valor1 == "") {
            span1.hide();
        }
    });

    // FUNCION PARA CO
    pass2.keyup(function () {
        coincidePassword();
    });

    /*  Activate the tooltips      */
    $('[rel="tooltip"]').tooltip();

    // Code for the Validator
    var $validator = $('.wizard-card form').validate({
        rules: {
            PRIMER_NOMBRE: {
                required: true
            },
            SEGUNDO_NOMBRE: {
                required: true
            },
            PRIMER_APELLIDO: {
                required: true
            },
            SEGUNDO_APELLIDO: {
                required: true
            },
            SEXO: {
                required: true
            },
            DUI: {
                required: true
            },
            TELEFONO_FIJO: {
                required: true
            },
            TELEFONO_MOVIL: {
                required: true
            },
            DEPARTAMENTO: {
                required: true
            },
            DIRECCION: {
                required: true
            },
            CORREO_INSTITUCIONAL: {
                required: true
            },
            FECHA_INGRESO: {
                required: true
            },
            PROFESION: {
                required: true
            },
            FACULTAD: {
                required: true
            },
            NOMBRE_USUARIO: {
                required: true
            },
            PASSWORD: {
                required: true
            }
        },
        messages: {
            PRIMER_NOMBRE: "Nombre Requerido",
            SEGUNDO_NOMBRE: "Nombre Requerido",
            PRIMER_APELLIDO: "Apellido Requerido",
            SEGUNDO_APELLIDO: "Apellido Requerido",
            SEXO: "Campo Sexo es Requerido",
            DUI: "Campo DUI es Requerido",
            TELEFONO_FIJO: "Tel\351fono Fijo es Requerido",
            TELEFONO_MOVIL: "Tel\351fono Movil es Requerido",
            DEPARTAMENTO: "El Departamento es Requerido",
            DIRECCION: "La Direcci\363n es Requerida",
            CORREO_INSTITUCIONAL: "El Correo Institucional es Requerido",
            FECHA_INGRESO: "La Fecha de Ingreso es Requerida",
            PROFESION: "La Profesi\363n es Requerida",
            FACULTAD: "La Facultad es Requerida",
            NOMBRE_USUARIO: "El Nombre de Usuario es Requerido",
            PASSWORD: "La Contrase\361a es Requerida"
        }
    });

    // Wizard Initialization
    $('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {
            var $valid = $('.wizard-card form').valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        },

        onInit: function (tab, navigation, index) {

            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            $width = 100 / $total;
            var $wizard = navigation.closest('.wizard-card');

            $display_width = $(document).width();

            if ($display_width < 600 && $total > 3) {
                $width = 50;
            }

            navigation.find('li').css('width', $width + '%');
            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.wizard-card .wizard-navigation').append($moving_div);
            refreshAnimation($wizard, index);
            $('.moving-tab').css('transition', 'transform 0s');
        },

        onTabClick: function (tab, navigation, index) {

            var $valid = $('.wizard-card form').valid();

            if (!$valid) {
                return false;
            } else {
                return true;
            }
        },

        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.wizard-card');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');

            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });


    // Prepare the preview for profile picture
    $("#wizard-picture").change(function () {
        readURL(this);
    });

    $('[data-toggle="wizard-radio"]').click(function () {
        wizard = $(this).closest('.wizard-card');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked', 'true');
    });

    $('[data-toggle="wizard-checkbox"]').click(function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).find('[type="checkbox"]').removeAttr('checked');
        } else {
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked', 'true');
        }
    });

    $('.set-full-height').css('height', 'auto');

});



//Function to show image before upload

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$(window).resize(function () {
    $('.wizard-card').each(function () {
        $wizard = $(this);
        index = $wizard.bootstrapWizard('currentIndex');
        refreshAnimation($wizard, index);

        $('.moving-tab').css({
            'transition': 'transform 0s'
        });
    });
});

function refreshAnimation($wizard, index) {
    total_steps = $wizard.find('li').length;
    move_distance = $wizard.width() / total_steps;
    step_width = move_distance;
    move_distance *= index;

    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
        'transition': 'all 0.3s ease-out'

    });
}

function debounce(func, wait, immediate) {
    var timeout;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            timeout = null;
            if (!immediate) func.apply(context, args);
        }, wait);
        if (immediate && !timeout) func.apply(context, args);
    };
};
