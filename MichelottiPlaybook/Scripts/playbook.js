$(function () {
    // needed for Bootstrap dropdowns
    $('.dropdown-toggle').dropdown();

    // set active for main nav bar
    $("ul.nav li:has(a[href='" + window.location.pathname + "'])").addClass("active");

    //    $("ul.nav li").click(function () {
    //        //console.log("click", this);
    //        $(this).parent().find("li").removeClass("active");
    //        $(this).addClass("active");
    //    });
});