$(document).ready(() => {

    feather.replace();

    (function () {
        'use strict'

        let forms = document.querySelectorAll('.needs-validation');

        Array.prototype.slice.call(forms)
            .forEach(function (form) {
                form.addEventListener('submit', function (event) {
                    if (!form.checkValidity()) {
                        event.preventDefault();
                        event.stopPropagation();
                    }

                    form.classList.add('was-validated');
                }, false)
            })
    })();

    $(".search-input-btn").click(e => {
        e.preventDefault();

        let $btn = $(e.target);
        let $input = $($btn.prev(".search-input"));
        let $form = $($input.closest("form"));
        let val = $input.val();

        console.log($input);
        console.log(val);

        location.replace($form.attr("action") + "?query=" + val)
    });

    $(".comment-like-btn").click(e => {
        e.preventDefault();

        let $a = $(e.target);
        let action = $a.attr("href");

        $.post(action).done(...data => {
            console.log(data);
        }).fail(...data => {
            console.log(data);
        });
    });

    $(".article-like-btn").click(e => {
        e.preventDefault();

        let $a = $(e.target);
        let action = $a.attr("href");

        $.post(action).done(...data => {
            console.log(data);
        }).fail(...data => {
            console.log(data);
        });
    })
});