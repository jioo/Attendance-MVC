
// NOTE: time-in js

var input = $('#SchedStart');
input.clockpicker({
    autoclose: true
});
$('#btn-timein').click(function (e) {
    // Have to stop propagation here
    e.stopPropagation();
    input.clockpicker('show')
    .clockpicker('toggleView', 'hours');
});

// NOTE: time-out js

var input1 = $('#SchedEnd');
input1.clockpicker({
    autoclose: true
});
$('#btn-timeout').click(function (e) {
    // Have to stop propagation here
    e.stopPropagation();
    input1.clockpicker('show')
    .clockpicker('toggleView', 'hours');
});
