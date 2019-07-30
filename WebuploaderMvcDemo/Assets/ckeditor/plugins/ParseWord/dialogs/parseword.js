(function () {
    var uploader;
    function initWebUploader(editor, _dialog, id) {
        if (typeof WebUploader === 'undefined') { return; }
        if (WebUploader.Uploader.support() === false) {
            alert('上传组件不支持您的浏览器！如果你使用的是IE浏览器，请尝试升级 flash 播放器');
            throw new Error('WebUploader does not support the browser you are using.');
        }
        uploader = WebUploader.create({
            domId: id,
            auto: true,
            swf: editor.config._assets_base_path + '/assets/js/webuploader/flash/Uploader.swf',
            server: editor.config._parse_word_url,
            formData: {},
            pick: '#picker-' + id,
            fileNumLimit: 0,
            fileSizeLimit: 10 * 20 * 1024 * 1024,
            fileSingleSizeLimit: 20 * 1024 * 1024,//20M

            accept: {
                title: '选择文件',
                extensions: 'doc,docx',
                mimeTypes: 'application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document',
            }
        });
        // 当有文件添加进来的时候
        uploader.on('fileQueued', function (file) {
            BlockPage('文件上传中...');

            var $fileWrap = $(uploader.options.pick).parents('table.f-upload-table').eq(0).find('.uploader-list').eq(0);
            //判断是上传图片并且单图片上传
            $('.thumbnail', $fileWrap).remove();
            //再添加
            var _html = [];
            _html.push('<li id="' + file.id + '" class="file-item" style="margin:0;width:200px;float:none;padding:25px;">');
            //_html.push('<div class="js-remove-file-fex"></div>');
            _html.push('<div class="info" style="background:transparent;color:#000;"><img src="../images/doc.gif">' + file.name + '</div>');
            _html.push('</li>');

            var $li = $(_html.join(''));
            var $img = $li.find('img.f-thum-img');
            // $list为容器jQuery实例
            var $list = $fileWrap.append($li);
        });
        // 文件上传过程中创建进度条实时显示。
        uploader.on('uploadProgress', function (file, percentage) {
        });
        // 文件上传成功，给item添加成功class, 用样式标记上传成功。
        uploader.on('uploadSuccess', function (file, response) {
            UnBlockPage();
            //插入editor编辑器
            editor.insertHtml(response.Cnt);
            dTooltip('上传成功 :)', 2500, true);
            //关闭弹出框
            _dialog.hide();
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

    function ParseWordDialog(editor) {
        var _html = [];
        if (typeof WebUploader === 'undefined') {
            alert('缺少上传组件');
            _html.push('缺少上传组件');
        } else {
            _html.push('<link href="' + editor.config._assets_base_path + '/Assets/js/webuploader/css/webuploader.css" rel="stylesheet" />');
            _html.push('<link href="' + editor.config._assets_base_path + '/Assets/js/webuploader/css/demo.css" rel="stylesheet" />');

            _html.push('<table class="f-upload-table">');
            _html.push('<tbody>');
            _html.push('<tr class="hide">');
            _html.push('        <td>');
            _html.push('            <ul class="list-unstyled uploader-list">');
            _html.push('            </ul>');
            _html.push('        </td>');
            _html.push('</tr>');
            _html.push('<tr>');
            _html.push('    <td>');
            _html.push('        <div class="btns">');
            _html.push('            <table>');
            _html.push('                <tbody>');
            _html.push('                    <tr>');
            _html.push('                        <td class="hide">');
            _html.push('                            <input type="hidden" id="bd-wfile" name="wfile" />');
            _html.push('                        </td>');
            _html.push('                        <td style="padding-top: 5px;">');
            _html.push('                            <div id="picker-bd-wfile">选择文件</div>');
            _html.push('                        </td>');
            _html.push('                    </tr>');
            _html.push('                </tbody>');
            _html.push('            </table>');
            _html.push('        </div>');
            _html.push('    </td>');
            _html.push('</tr>');

            _html.push('</tbody>');
            _html.push('</table>');
        }
        return {
            title: '解析Word',
            minWidth: 300,
            minHeight: 80,
            contents: [{ id: 'w-iframe', label: '', title: '', elements: [{ type: 'html', html: _html.join('') }] }],
            buttons: [CKEDITOR.dialog.cancelButton],
            onShow: function () {
                if (typeof uploader === 'undefined') {
                    initWebUploader(editor, this, 'bd-wfile');
                }
            }
        };
    };

    CKEDITOR.dialog.add('ParseWord', function (editor) {
        return ParseWordDialog(editor);
    });
})();