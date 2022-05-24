function createUserLoaded() {
    loadRegions();
}

function loadRegions() {
    $.ajax({
        url: "/api/region",
        type: "GET",
        success: function (data) {
            data.forEach(el => $("#region").append("<option value='" + el + "'>" + el + "</option>"));
        },
        error: function (data) {
            /*error handler*/
            console.log(data.responseJSON);
        }
    });
}

function loadCountries() {
    $("#country option").remove();
    $("#country").append("<option selected disabled hidden>Country</option>")
    var region = $("#region").val();
    $.get({
        url: "/api/country?region=" + region,
        type: "GET",
        success: function (data) {
            data.forEach(el => $("#country").append("<option value='" + el + "'>" + el + "</option>"));
            $("#country").prop("disabled", false);
        },
        error: function (data) {
            /*error handler*/
            console.log(data.responseJSON);
        }
    });
}

function sendUser() {
    clearErrors();
    var model = {
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        email: $("#email").val(),
        region: $("#region").val(),
        country: $("#country").val()
    };
    var request = JSON.stringify(model);
    $.post({
        url: "/api/user",
        type: "POST",
        data: request,
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            var parameters = "";
            for (var key in data) {
                parameters += key + "=" + data[key] + "&";
            }

            window.location.href = "/user/index?" + parameters.slice(0, -1);
        },
        error: function (data) {
            /*error handler*/
            console.log(data.responseJSON);
            handleValidationError(data.responseJSON)
        }
    });
}

function clearErrors() {
    $("#firstName").removeClass("is-invalid");
    $("#firstNameError span").remove();
    $("#firstNameError br").remove();
    $("#firstNameError").prop("hidden", true);

    $("#lastName").removeClass("is-invalid");
    $("#lastNameError span").remove();
    $("#lastNameError br").remove();
    $("#lastNameError").prop("hidden", true);

    $("#email").removeClass("is-invalid");
    $("#emailError span").remove();
    $("#emailError br").remove();
    $("#emailError").prop("hidden", true);

    $("#region").removeClass("is-invalid");

    $("#country").removeClass("is-invalid");
}

function handleValidationError(json) {
    if (json.errors.FirstName !== undefined) {
        $("#firstName").addClass("is-invalid");
        json.errors.FirstName.forEach(el => $("#firstNameError").append("<span>" + el + "</span></br>"));
        $("#firstNameError").prop("hidden", false);
    }

    if (json.errors.LastName !== undefined) {
        $("#lastName").addClass("is-invalid");
        json.errors.LastName.forEach(el => $("#lastNameError").append("<span>" + el + "</span></br>"));
        $("#lastNameError").prop("hidden", false);
    }

    if (json.errors.Email !== undefined) {
        $("#email").addClass("is-invalid");
        json.errors.Email.forEach(el => $("#emailError").append("<span>" + el + "</span></br>"));
        $("#emailError").prop("hidden", false);
    }

    if (json.errors.Region !== undefined) {
        $("#region").addClass("is-invalid");
    }

    if (json.errors.Country !== undefined) {
        $("#country").addClass("is-invalid");
    }
}