$(function () {
    $('<li role="presentation"><a href="#security" aria-controls="security" role="tab" data-toggle="tab"><i class="fa fa-key" aria-hidden="true"></i> Ключи</a></li>').insertBefore($('a[href="#recomendations"]').parent('li'));
    $('<div id="security" class="tab-pane" role="tabpanel"><div id="grid-security"></div></div>').insertBefore('.tab-content #recomendations');
    $('a[href="#security"]').one('click', function () {
        new SxGridView('#grid-security');
    });
    $('a[href="#security"]').on('shown.bs.tab', function (e) {
        var $a = $(e.target);

        $.ajax({
            method: 'get',
            url: '/siteprojectsecurityitems?projectId=5',
            beforeSend: function () {
                $a.prepend('<i class="fa fa-spinner fa-spin" aria-hidden="true"></i> ');
            },
            success: function (data) {
                $('#grid-security').html(data);
                $a.find('.fa-spinner').remove();
            }
        });
    });
});