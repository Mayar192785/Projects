
//#region preapre vars and global parts
var calendarEvents = [];

var calendarStartDate = new Date().getDate;

var calendarSettings = {
    calendarItemsUrl: 'nodata',
    CalendarNewUrl: "nodata",
    CalendarNewUrl: "/Meeting/mmMeetings/CreateAutommmmm",
    startDate: moment(calendarStartDate).isValid() ? moment(calendarStartDate) : moment(),
    aspectRatio: 2,
    firstDay: 0, // sunday
    firstHour: 0,
    eventcolor: '#378006',
    createNewMsg: "Create new Event ??",
};
//#endregion


function generateCalendar(calendarEvents) {
    $('#calendar').fullCalendar('destroy');
    $('#calendar').fullCalendar({
        //contentHeight: 400,
        defaultView: 'agendaWeek',
        defaultDate: calendarSettings.startDate,
        aspectRatio: calendarSettings.aspectRatio,
        firstDay: calendarSettings.firstDay, // Sunday=0, Monday=1 etc
        firstHour: calendarSettings.firstHour,
        timeFormat: 'h(:mm)a',
        header: {
            left: 'prev,next,today',
            center: 'title',
            right: 'month,basicWeek,basicDay,agenda,agendaWeek'
        },
        eventLimit: true,
        eventColor: calendarSettings.eventcolor,
        events: calendarEvents,
        eventClick: function (calEvent, jsEvent, view) {
            $('#myModal #eventTitle').text(calEvent.title);
            var $description = $('<div/>');
            $description.append($('<p/>').html('<b>Start Date :<b/>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));

            if (calEvent.end != null) {
                $description.append($('<p/>').html('<b>End Date :<b/>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
            }
            $description.append($('<p/>').html('<b>Description :<b/>' + calEvent.description));


            $('#myModal #pDetails').empty().html($description);
            var $description2 = $("<hr/>");
            //$description2.append($('<span>').html('<a href="/PrMaintenance/pmPreventiveMaint/Edit/' + calEvent.id + '" class=\"btn btn-primary\" target=\"_blank\" >Go To Edit</a>'));
            //$description2.append($('<span>').html('<a href="/PrMaintenance/pmWorkOrders/Details/' + calEvent.id + '" class=\"btn btn-primary\" target=\"_blank\" >Go To Details</a>'));

            if (calEvent.color === 'Gray')
                $description2 = $("<p>Vacation</p>");
            $('#myModal #goto').empty().html($description2);
            $('#myModal').modal();
        },

        eventRender: function (event, element) {
            element.qtip({
                content: (event.description) || 'Empty',
                style: {
                    classes: 'qtip-bootstrap'
                }
            });
        },

        selectable: true,
        selectHelper: true,
        select: function (start, end, allDay) {
            if (confirm(calendarSettings.createNewMsg)) {
                var startDate = moment(start).format("L");
                var StartTime = moment(start).format("hh:mm");
                var EndTime = moment(end).format("hh:mm");

                url = calendarSettings.CalendarNewUrl + "?EventDate=" + startDate + "&StartTime=" + StartTime + "&EndTime=" + EndTime;
                window.open(url, "_blanck");

            }
        },

    });
    
};
