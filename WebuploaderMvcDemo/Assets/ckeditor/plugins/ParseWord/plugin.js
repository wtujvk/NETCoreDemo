CKEDITOR.plugins.add('ParseWord', {
    requires: ["dialog"],
    init: function (editor) {
        var pluginName = 'ParseWord';
        editor.addCommand(pluginName, new CKEDITOR.dialogCommand(pluginName));
        editor.ui.addButton(pluginName,
        {
            label: '解析Word',
            command: pluginName,
            icon: this.path + 'images/doc.gif'
        });
        CKEDITOR.dialog.add(pluginName, this.path + 'dialogs/parseword.js');        
    }
});