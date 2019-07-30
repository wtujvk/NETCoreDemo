/**/
var _web_uploader_list = [];
function WebUploaderBind(uploader, hidDom, _thumbnail_width, _thumbnail_height, img_list) {
    _web_uploader_list.push(uploader);
    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) {

        var $fileWrap = $(uploader.options.pick).parents('table.f-upload-table').eq(0).find('.uploader-list').eq(0);
        //判断是上传图片并且单图片上传
        if (uploader.options.fileNumLimit == 1) { /*移除掉之前页面上的*/ $('.thumbnail', $fileWrap).remove(); }
        //再添加
        var _id = file.id;
        var _html = [];
        if (img_list == "") {
            _html.push('<li id="' + _id + '" class="file-item thumbnail">');
            _html.push('<div class="js-remove-file-fex" data-hide="' + hidDom + '"></div>');
            _html.push('<img class="f-thum-img"/>');
            _html.push(FileIcon(file.name));
            _html.push('<div class="info">' + file.name + '</div>');
            _html.push('</li>');
        } else {
            _html.push('<li id="' + _id + '" class="file-item thumbnail"  style="border:none;">');
            _html.push('<div class="pull-left">');
            _html.push('<img class="f-thum-img" style="max-width:100px;max-height:100px;" />');
            _html.push('</div><div class="pull-right" style="margin-left: 10px;width:310px;"><div>');
            _html.push('名称：' + FileIcon(file.name));
            _html.push('<div class="info">' + file.name + '</div>');
            _html.push('<div class="js-remove-file-fex-list" data-hide="' + hidDom + '">');
            _html.push('</div></div><div style="padding-top: 8px;">');
            _html.push('<textarea class="form-control" style="width: 310px; resize: none; margin-top: 0px; margin-bottom: 0px; height: 73px;" placeholder="请简短的填写一下描述"></textarea></div></div>');

            _html.push('</li>');
        }


        var $li = $(_html.join(''));
        var $img = $li.find('img.f-thum-img');
        // $list为容器jQuery实例
        var $list = $fileWrap.append($li);

        // 优化retina, 在retina下这个值是2
        var ratio = window.devicePixelRatio || 1,

        // 缩略图大小
        _thumbnail_width = _thumbnail_width * ratio;
        _thumbnail_height = _thumbnail_height * ratio;

        // 创建缩略图
        // 如果为非图片文件，可以不用调用此方法。
        // thumbnailWidth x thumbnailHeight 默认为 100 x 100
        uploader.makeThumb(file, function (error, src) {
            if (error) { $img.replaceWith('<div class="f-not-preview"></div>'); return; }
            $img.attr('src', src);
        }, _thumbnail_width, _thumbnail_height);

    });
    // 文件上传过程中创建进度条实时显示。
    uploader.on('uploadProgress', function (file, percentage) {
        var $li = $('#' + file.id), $percent = $li.find('.progress span');
        // 避免重复创建
        if (!$percent.length) { $percent = $('<p class="progress"><span></span></p>').appendTo($li).find('span'); }
        $percent.css('width', percentage * 100 + '%');
    });
    // 文件上传成功，给item添加成功class, 用样式标记上传成功。
    uploader.on('uploadSuccess', function (file, response) {
        if (response.State === 0) {
            $('#' + file.id).addClass('upload-state-done').data('file', response.Url);
            //Url
            var _hide_value = $('#' + hidDom).val();
            if (_hide_value.length === 0 || uploader.options.fileNumLimit == 1) { _hide_value = response.Url; }
            else { _hide_value += (',' + response.Url); }

            $('#' + hidDom).val(_hide_value);
            $('#js-file-obj-' + hidDom).val(response._raw);
            //if ($("div").hasClass("face-img")) {
            //    $("#face-img").attr("src", response.Url);
            //}

        } else {
            var $li = $('#' + file.id), $error = $li.find('div.error');
            // 避免重复创建
            if (!$error.length) { $error = $('<div class="error">服务器出错 :(</div>').appendTo($li); }
            $error.text(response.ErrorMessage);
        }
        //判断是上传图片并且单图片上传
        if (uploader.options.fileNumLimit === 1 || uploader.options._InputModel === true) {
            //移除_web_uploader_list对象中的
            for (var i = 0; i < _web_uploader_list.length; i++) {
                try { _web_uploader_list[i].removeFile(file, true); } catch (ex) { }
            }
        }
    });
    // 文件上传失败，显示上传出错。
    uploader.on('uploadError', function (file) {
        var $li = $('#' + file.id), $error = $li.find('div.error');
        // 避免重复创建
        if (!$error.length) { $error = $('<div class="error">文件上传失败~!</div>').appendTo($li); }
        $error.text('Upload Error');
    });
    // 完成上传完了，成功或者失败，先删除进度条。
    uploader.on('uploadComplete', function (file) { $('#' + file.id).find('.progress').remove(); });
    uploader.on('error', function (type, file) {
        switch (type) {
            case "Q_EXCEED_NUM_LIMIT":
                alert('文件数量超过限制 :(');
                break;
            case "F_EXCEED_SIZE":
                alert('上传的文件太大 :(');
                break;
            case "F_DUPLICATE":
                alert('重复的文件 :(');
                break;
            case "Q_EXCEED_SIZE_LIMIT":
                alert('上传的文件太大 :(');
                break;
            case "Q_TYPE_DENIED":
                alert('不能上传此类型的文件 :(');
                break;
        }
    });
}
function FileIcon(file) {

    var fileExt = file.substring(file.lastIndexOf('.') + 1).toLowerCase();
    var iconPath = "/Assets/ueditor/dialogs/attachment/fileTypeImages/icon_{0}.gif";

    switch (fileExt) {
        case "chm":
        case "exe":
        case "jpg":
        case "mp3":
        case "mv":
        case "pdf":
        case "psd":
        case "rar":
        case "txt":
            iconPath = iconPath.replace('{0}', fileExt);
            break;
        case "ppt":
        case "pptx":
            iconPath = iconPath.replace('{0}', "ppt");
            break;
        case "doc":
        case "docx":
            iconPath = iconPath.replace('{0}', "doc");
            break;
        case "xls":
        case "xlsx":
            iconPath = iconPath.replace('{0}', "xls");
            break;
        case "jpg":
        case "png":
        case "gif":
        case "bmp":
            iconPath = iconPath.replace('{0}', "jpg");
            break;
        default:
            iconPath = iconPath.replace('{0}', "txt");
            break;
    }
    var _html = ['<img src="{0}" class="f-icon" />'.replace('{0}', iconPath)];
    _html.push('<span class="f-sp-name">&nbsp;{0}</span>'.replace('{0}', file));
    return _html.join('');
}

/*绑定删除文件事件*/
$(document).on('click', '.js-remove-file-fex', function () {
    var $this = $(this);
    var $fileWrap = $this.parent();
    for (var i = 0; i < _web_uploader_list.length; i++) {
        try { _web_uploader_list[i].removeFile($fileWrap.attr('id'), true); } catch (ex) { }
    }
    if ($fileWrap.data('file') === undefined) { $fileWrap.remove(); return; }

    layer.confirm('确定删除吗？删除后不可恢复！', {
        btn: ['删除', '取消'] //按钮
    }, function () {
        /*执行删除*/
        $.post(_del_file_server, { file: $fileWrap.data('file') }, function (rdata) {
            if (rdata.err === false) {
                // alert("删除成功");
                layer.msg("删除成功！请保存数据！", { icon: 1 });
                var _DataImages = $('#' + $this.data('hide')).val();
                _DataImages = _DataImages.replace($fileWrap.data('file'), '');
                $('#' + $this.data('hide')).val(_DataImages);
                $fileWrap.remove();

                setTimeout(function () { layer.closeAll(); }, 1000)

            }
            else {
                layer.closeAll();
                layer.msg(rdata.msg, { icon: 2 });
                // $.tooltip(rdata.msg);
            }
        }, 'JSON');
    }, function () {
        layer.closeAll();
    });
});

//js-remove-file-fex-list
/*绑定删除文件事件*/
$(document).on('click', '.js-remove-file-fex-list', function () {
    var $this = $(this);
    var $fileWrap = $this.closest("li");
    //alert($fileWrap.html()); return;
    for (var i = 0; i < _web_uploader_list.length; i++) {
        try { _web_uploader_list[i].removeFile($fileWrap.attr('id'), true); } catch (ex) { }
    }
    if ($fileWrap.data('file') === undefined) {
        //   alert("ok");
        $fileWrap.remove(); return;
    }

    layer.confirm('确定删除吗？删除后不可恢复！', {
        btn: ['删除', '取消'] //按钮
    }, function () {
        /*执行删除*/
        $.post(_del_file_server, { file: $fileWrap.data('file') }, function (rdata) {
            if (rdata.err === false) {
                // alert("删除成功");
                layer.msg("删除成功！请保存数据！", { icon: 1 });
                var _DataImages = $('#' + $this.data('hide')).val();
                _DataImages = _DataImages.replace($fileWrap.data('file'), '');
                $('#' + $this.data('hide')).val(_DataImages);
                $fileWrap.remove();

                setTimeout(function () { layer.closeAll(); }, 1000)

            }
            else {
                layer.closeAll();
                layer.msg(rdata.msg, { icon: 2 });
                // $.tooltip(rdata.msg);
            }
        }, 'JSON');
    }, function () {
        layer.closeAll();
    });
});
