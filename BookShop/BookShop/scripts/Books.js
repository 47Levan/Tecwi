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
    top: '-40px',
    position: 'relative'
};

var spinner = new Spinner(spinOpts);
$(document).ready(() => {
    $("#AddBookForm").validate({
        rules: {
            AuthorInput: "required",
            TitleInput: "required",
            PictureUrl: "required",
            DecriptionInput: "required"
        },
        messages: {
            AuthorInput: "Please enter author",
            TitleInput: "Please enter title",
            PictureUrl: "Please enter picture",
            DecriptionInput: "Please enter description"
        },
        submitHandler: function (form) {
            var data = new FormData();
            var files = $("#PictureFile").get(0).files;
            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
            }
            data.append("Author", $("#AuthorInput").val());
            data.append("Title", $("#TitleInput").val());
            data.append("PictureUrl", $("#PictureUrl").val());
            data.append("Decription", $("#DecriptionInput").val());
            GetBooks("/Books/AddBook", data, false, false, UpdateGrid);
        }

    });
    GetBooks("/Books/PostBooks", null
        , 'application/x-www-form-urlencoded; charset=UTF-8', true, UpdateGrid);
    $("#SearchBook").on("input", function () {
        GetBooks("/Books/PostBooks", { "": $("#SearchBook").val() }
            , 'application/x-www-form-urlencoded; charset=UTF-8', true, data => {
                AutoComplete(data);
                UpdateGrid(data);
            });
    });
    $("#HomeHref,#HomeHrefFooter").on("click", function () {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#AddBook").offset().top
        }, 2000);
    });
    $("#AboutHref,#AboutHrefFooter").on("click", function () {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#About").offset().top
        }, 2000);
    });

    $("#ContactsHref,#ContactsHrefFooter").on("click", function () {
        event.preventDefault();
        $('html, body').animate({
            scrollTop: $("#Contacts").offset().top
        }, 2000);
    });
    $(document).scroll(function () {
        if ($(window).scrollTop() >= 250) {
            //    $(".nav.navbar-nav").animate({
            //        height:1
            //});
            $(".navbar.navbar-default.navbar-static-top .nav.navbar-nav").css("position", "Fixed");
            $(".navbar.navbar-default.navbar-static-top .nav.navbar-nav").css("top", "0px");
        }
        if ($(window).scrollTop() < 250) {
            $(".navbar.navbar-default.navbar-static-top .nav.navbar-nav").css("position", "");
            $(".navbar.navbar-default.navbar-static-top .nav.navbar-nav").css("top", "");
        }
    });

    GetMap();
});

function AutoComplete(data) {
    $("#ContactsHref").autocomplete({
        source: (request, response) => {
            response($.map(data, (item) => {
                return { label: item.Title + " (" + item.Author + ")", value: item.Title }
            }));
        },
        select: (event, element) => {
            GetBooks("/Books/PostBooks", { "": element.item.value }
                , 'application/x-www-form-urlencoded; charset=UTF-8', true, UpdateGrid);
        }
    }
    )
};
function UpdateGrid(data) {
    var bookCont = $("#BooksContainer");
    $("#NoResults").empty();
    if (data.toString() != "") {
        $.each(data, (key, item) => {
            bookCont.append('<div class="bookCell">'
                + '<div>'
                + '<h4 class="title">' + item.Title + "</h4>"
                + '<p>' + item.Author + "</p>"
                + "</div>"
                + '<img src="' + item.Picture + '"/>'
                + '<div class="decription">' + item.Description + "</div>"
                + "</div>");
            $(".decription").succinct({
                size: 150
            });
            $(".title").succinct({
                size: 50
            });
        });
    } else {
        $("#BooksContainer").empty();
        $("#NoResults").append("<h1>Sorry!<h1><h4>your search didn't bring result</h4>");
    }
}
function GetBooks(url, data, contentType, processData, successCallback) {
    $.ajax({
        url: url,
        type: "POST",
        data: data,
        contentType: contentType,
        processData: processData,
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
function AddBook(data) {
    if (data != null)
        UpdateGrid(data);
}

function GetMap() {
    var Kiev = new google.maps.LatLng(50.4318986, 30.5153224);
    var mapOptions = {
        zoom: 15,
        center: Kiev,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);
    var marker = new google.maps.Marker({
        position: Kiev,
        map: map,
        title: "Shop location",
    })
    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png');
    var infoWindow = new google.maps.InfoWindow({
        content: "<div><h2>Company name:Bridge of books</h2>" +
             "<div><h4>Company branch:selling books</h4>" +
             "<img src='http://pngimg.com/upload/book_PNG2116.png' " +
            "style='width:100px;height:auto'/></div></div>"
    })
    google.maps.event.addListener(marker, 'click', function () {
        infoWindow.open(map, marker);
    });
}
