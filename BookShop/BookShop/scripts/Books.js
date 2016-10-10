var opts = {
    lines: 9,
    length: 27,
    width: 5,
    radius: 38,
    scale: 1,
    corners: 1,
    color: '#a5b605',
    opacity: 0.5,
    direction: 1,
    speed: 1.9,
    trail: 50,
    zIndex: 2e9,
    left: '50%',
    top:'90px',
    position: 'relative'
};
$(document).ready(function () {
    var spinner = new Spinner(opts);
    $.ajax({
        url: "/api/UpdateBooksGrid",
        beforeSend: function () {
            $("#Loading").fadeTo("slow", 0.7);
            $("#Loading").after(spinner.spin().el);
        },
        complete: function () {
            $("#Loading").fadeOut();
            spinner.stop();
        },
        success: function (data) {
            var bookCont = $("#BooksContainer");
            var decriptionHeight = 16*7*1.5;
            $.each(data, function (key, item) {
                bookCont.append('<div  style="height:auto;width:200px;margin-left:100px'
                    + ' ">'
                    + '<div style="height:100px">'
                    + '<h4 style="height:60px;overflow:hidden">' + item.Title + "</h4>"
                    + '<p>' + item.Author + "</p>"
                    + "</div>"
                    + '<img style="height:200px;width:150px" src="' + item.Picture + '"/>'
                    + '<div style="margin-top:25px;overflow:hidden;line-height:1.5; ' 
                    + '-webkit-line-clamp:7;-webkit-box-orient: vertical;height:' + decriptionHeight + 'px;">'
                    + item.Description + "</div>"
                    + "</div>");
            });
        }
    });
});