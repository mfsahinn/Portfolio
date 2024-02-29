function isUndefined(obj) {
    if (typeof obj === 'undefined')
        return true;
    else
        return false;
}

function DataTablePrepare(tableId, dataURL, columnOptions, extraObjectfunction, orderOptions) {
    var exportColumns = [];
    if (Array.isArray(columnOptions)) {
        columnOptions.forEach((element, index) => {
            if (isUndefined(element.export) || element.export == true)
                exportColumns.push(index);
        });
    }

    var dataTable = $('#' + tableId).dataTable(
        {
            processing: true,
            serverSide: true,
            responsive: true,
            paging: true,
            order: orderOptions,
            ajax: {
                url: dataURL,
                type: 'POST',
                data: function (d) {
                    if (!isUndefined(extraObjectfunction) && extraObjectfunction != null) {
                        var extraObject = extraObjectfunction();
                        if (!isUndefined(extraObject) && extraObject != null) {
                            for (const key of Object.keys(extraObject)) {
                                d[key] = extraObject[key]
                            };
                        }
                    }
                },
                error: function (xhr, error, code) {
                    switch (xhr.status) {
                        case 401:
                            alert("Veri listeleme işlemi için oturum açmanız gerekmektedir.");
                            break;
                        case 403:
                            alert("Veri listeleme işlemi için yetkiniz bulunmamaktadır.");
                            break;
                        default:
                            alert("Bilinmeyen Hata. Lütfen sistem yöneticisi ile irtibata geçiniz.");
                            break;
                    }
                }
            },
            columns: columnOptions,
            language: {
                url: '/js/DataTable/DataTable_tr-TR.json'
            }
        });

    dataTable.on('xhr.dt', function (e, settings, json, xhr) {
        json.draw = parseInt(json.RequestId);
        json.recordsTotal = parseInt(json.TotalRecordCount);
        json.recordsFiltered = parseInt(json.FilteredRecordCount);
        json.data = json.Data;
    });

    return dataTable;
}