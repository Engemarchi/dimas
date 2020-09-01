(function (context) {

    context.engemarchi = {

        page: {

            onDocumentReady: function () {
                document.querySelector(".login-entrar").addEventListener("click", function (e) {
                    e.preventDefault();

                });
            }

        },

    };

    document.addEventListener("DOMContentLoaded", context.engemarchi.page.onDocumentReady);

})(window);