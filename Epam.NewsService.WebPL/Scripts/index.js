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

        let $a = $(e.currentTarget);
        let action = $a.attr("href");
        let type = 0;

        if ($a.hasClass("like-active")) {
            type = 1;
        }

        $.post(action + "?type=" + type).done(() => {
            $a.toggleClass("like-active");
        }).fail(data => {});
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
    });

    $(".toast-close-btn").click(e => {
        let $toast = $($(e.target).closest(".toast"));

        $toast.toggleClass("show");
    });

    $(".comment-send-btn").click(e => {
        e.preventDefault();

        let $btn = $(e.target);
        let $form = $($btn.closest("form"));
        let $textarea = $($form.find("textarea"));

        console.log($textarea);

        $.post($form.attr("action"), { content: $textarea.val() }).done(() => {
            location.reload();
        }).fail();
    });
});