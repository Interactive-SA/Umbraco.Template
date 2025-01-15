$(document).ready(function () {

    //$("#btnAjaxFilter").formAutoPost({ targetContainerSelector: '.gridContentAjax' });

    $(".btnAction").click(function () {

        var target = "_self";
        var action = $(this).attr("action");
        var formtarget = $(this).attr("formtarget");

        if (formtarget != '') {
            target = formtarget;
        }

        if (action != '' && action != '#') {

            var url = location.protocol + '//' + location.host + action;
            //window.location = url;

            if (action.toLowerCase().indexOf("http") >= 0) {
                url = action;
                target = "_blank";
            }

            var win = window.open(url, target);
            if (win) {
                //Browser has allowed it to be opened
                win.focus();
            } else {
                //Browser has blocked it
                alert('Please allow popups for this website');
            }
        }
    });

    $(".umbPagerLink_").click(function () {
        $("#Page").val($(this).attr("id").replace("page", ""));
        //search();
        window.location = window.location.href.split("?")[0]
            + "?Page=" + $("#Page").val()
            //+ "&PageSize=" + $("#PageSize").val()
            //+ "&Keyword=" + $("#Keyword").val()
            ;
    });


    $('#txtsitesearch').bind("enterKey", function (e) {
        $("#btnsitesearch").trigger("click");
    });
    $('#txtsitesearch').keyup(function (e) {
        if (e.keyCode == 13) {
            $(this).trigger("enterKey");
        }
    });
    $("#btnsitesearch").click(function () {
        var url = location.protocol + '//' + location.host
        window.location =
            //window.location.href.split("?")[0] 
            url
            + "/search/"
            + "?Page=" + 1
            + "&Keyword=" + $('#txtsitesearch').val()
            ;
    });

});
