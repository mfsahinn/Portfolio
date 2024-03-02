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
            dom:   "<'row mb-3'<'col-sm-12 col-md-6 d-flex align-items-center justify-content-start'f>" +
            "<'col-sm-12 col-md-6 d-flex align-items-center justify-content-end'B>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row mt-2'<'col-sm-12 col-md-4 d-flex justify-content-start'i><'col-sm-12 col-md-4 d-flex justify-content-center'p>" +
            "<'col-sm-12 col-md-4 d-flex justify-content-end'l>>",
            
            buttons: [
              {
                extend: 'collection',
                className: 'btn btn-label-primary dropdown-toggle me-2',
                text: '<i class="ti ti-file-export me-sm-1"></i> <span class="d-none d-sm-inline-block">Export</span>',
                buttons: [
                  {
                    extend: 'print',
                    text: '<i class="ti ti-printer me-1" ></i>Print',
                    className: 'dropdown-item',
                   
                  },
                  {
                    extend: 'csv',
                    text: '<i class="ti ti-file-text me-1" ></i>Csv',
                    className: 'dropdown-item',
                  
                  },
                  {
                    extend: 'excel',
                    text: '<i class="ti ti-file-spreadsheet me-1"></i>Excel',
                    className: 'dropdown-item',
                  },
                  {
                    extend: 'pdf',
                    text: '<i class="ti ti-file-description me-1"></i>Pdf',
                    className: 'dropdown-item',
                  },
                  {
                    extend: 'copy',
                    text: '<i class="ti ti-copy me-1" ></i>Copy',
                    className: 'dropdown-item',
                   
                  }
                ]
              },
        
            ],
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