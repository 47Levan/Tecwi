var spinOpts = {
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
    left: '35%',
    top: '90px',
    position: 'relative'
};
$(document).ready(() => {
    GetBooks("/Books/PostBooks", null, UpdateGrid);
});
$("#SearchBook").on("input", () => {
    GetBooks("/Books/PostBooks", $("#SearchBook").val(), data => {
        AutoComplete(data);
        UpdateGrid(data);
    });
});
function AutoComplete(data) {
    $("#SearchBook").autocomplete({
        source: (request, response) => {
            response($.map(data, (item)=> {
                return { label: item.Title + " (" + item.Author + ")", value: item.Title }
            }));
        },
        select: (event, element) => {
            GetBooks("/Books/PostBooks", element.item.value, UpdateGrid);
        }
}
    )};
function UpdateGrid(data) {
    var bookCont = $("#BooksContainer");
    $.each(data, (key, item) => {
        bookCont.append('<div class="bookCell">'
            + '<div>'
            + '<h4 class="title">' + item.Title + "</h4>"
            + '<p>' + item.Author + "</p>"
            + "</div>"
            + '<img src="' + item.Picture + '"/>'
            + '<div class="decription">' + item.Description + "</div>"
            + '<a href="' + item.Id + '"><div>READ</div><div>MORE</div></a>'
            + "</div>");
        $(".decription").succinct({
            size: 150
        });
        $(".title").succinct({
            size: 50
        });
    });

}
function GetBooks(url,data,successCallback) {
    var spinner = new Spinner(spinOpts);
    return $.ajax({
        url: url,
        type: "POST",
        data: { "": data },
        beforeSend: () => {
            $("#BooksContainer").empty();
            $("#Loading").fadeTo("slow", 0.7);
            $("#Loading").after(spinner.spin().el);
        },
        complete: () => {
            $("#Loading").fadeOut();
            spinner.stop();
        },
        success: data => {
            successCallback(data);
        }
    });
}
