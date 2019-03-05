$(document).ready(function () {
    $('#bornagain').hide();
    $('#waterbaptised').hide();
    $('#SOM').hide();
    $('#Experience').hide();
    $('#SOD').hide();
    $('#BC').hide();
    $('#married').hide();
    $('input:radio[name=BornAgain]').change(function () {
        if (this.value == 'Yes') {
            $('#bornagain').show();
        }
        else if (this.value == 'No') {
            $('#bornagain').hide();
        }
    });

    $('input:radio[name=WaterBaptism]').change(function () {
        if (this.value == 'Yes') {
            $('#waterbaptised').show();
        }
        else if (this.value == 'No') {
            $('#waterbaptised').hide();
        }
    });
    $('input:radio[name=SOM]').change(function () {
        if (this.value == 'Yes') {
            $('#SOM').show();
        }
        else if (this.value == 'No') {
            $('#SOM').hide();
        }
    });

    $('input:radio[name=BC]').change(function () {
        if (this.value == 'Yes') {
            $('#BC').show();
        }
        else if (this.value == 'No') {
            $('#BC').hide();
        }
    });
    $('input:radio[name=SOD]').change(function () {
        if (this.value == 'Yes') {
            $('#SOD').show();
        }
        else if (this.value == 'No') {
            $('#SOD').hide();
        }
    });
    $('input:radio[name=IsExperienced]').change(function () {
        if (this.value == 'Yes') {
            $('#Experience').show();
        }
        else if (this.value == 'No') {
            $('#Experience').hide();
        }
    });
    $('input:radio[name=IsMarried]').change(function () {
        if (this.value == 'Yes') {
            $('#married').show();
        }
        else if (this.value == 'No') {
            $('#married').hide();
        }
    });
});

