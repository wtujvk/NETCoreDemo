define(function (require, exports, module) {
    // 通过 require 引入依赖
    var $ = require('jquery');
    var Raphael = require('raphael');
    var _ = require('underscore');
    //data c1
    var C1 = require('/Assets/sea-modules/static/Test/C1');
    var C2 = require('/Assets/sea-modules/static/Test/C2');
    var D1 = require('/Assets/sea-modules/static/Test/D1');
    var E1 = require('/Assets/sea-modules/static/Test/E1');
    //标段
    var _biao_duan_obj;
    //标段选择
    $('#js-bd').on('change', function () {
        var _val = $(this).find(':selected').val();
        switch (_val) {
            case 'C1':
                _biao_duan_obj = C1;
                break;
            case 'C2':
                _biao_duan_obj = C2;
                break;
            case 'D1':
                _biao_duan_obj = D1;
                break;
            case 'E1':
                _biao_duan_obj = E1;
                break;
            default:
                _biao_duan_obj = null;
                break;
        }
        var _html = ['<option value="">--请选择--</option>'];
        //清空
        $('#js-bridge,#js-lian').html(_html.join(''));
        $.each(_biao_duan_obj.Bridges, function (k, v) { _html.push('<option value="' + k + '">' + v.Name + '</option>'); });
        $('#js-bridge').html(_html.join(''));
    }).val('');
    //选中桥
    $('#js-bridge').on('change', function (k, v) {
        var _html = ['<option value="">--请选择--</option>'];
        $('#js-lian').html(_html.join(''));

        var _val = $(this).find(':selected').val();
        if (_val.length > 0) {
            var _lian_list = _biao_duan_obj.Bridges[parseInt(_val)].Z;
            $.each(_lian_list, function (k, v) { _html.push('<option value="' + v.L + '">' + v.L + '</option>'); });
        }
        $('#js-lian').html(_html.join(''));
    });
    //点击搜索
    $('#btnSearch').on('click', function () {
        var _biao_duan = $('#js-bd').find(':selected').val();
        var _qiao_name = $('#js-bridge').find(':selected').val();
        var _lian_bian_hao = $('#js-lian').find(':selected').val();
        if (_biao_duan.length == 0) { alert('请选择标段'); return false; }
        if (_qiao_name.length == 0) { alert('请选择桥'); return false; }
        if (_lian_bian_hao.length == 0) { alert('请选择联编号'); return false; }
        //获取数据
        $.ajax({
            async: false,
            data: { BD: _biao_duan_obj.Name, Lian: _lian_bian_hao },
            dataType: 'JSON',
            type: 'POST',
            url: ''
        }).done(function (data) {
            //先清空
            $('#svg-canvas').empty();
            //画布的宽
            var _paper_width = 600;
            //画布的高
            var _paper_height = 100;
            var paper = Raphael("svg-canvas", _paper_width, _paper_height);
            //起点x
            var _item_star_x = 60;
            //起点y
            var _item_star_y = 60;
            //每个标段的宽
            var _bd_item_width = 20;
            //每个标段的高
            var _bd_item_height = 100;
            //跨的宽
            var _bd_kua_width = 15;
            //跨的高
            var _bd_kua_height = 60;
            //跨的偏移
            var _bd_kua_offset = (_bd_item_width / 2 - 2);
            //桥的修正
            var _qiao_bd_xz = 10;
            //跨的修正
            var _bd_kua_xz = 5;
            //桥的高
            var _qiao_height = _bd_item_width;
            //桥的宽
            var _qiao_width = _bd_item_width;
            //信息框的高
            var _tips_height = 130;
            //信息框的宽
            var _tips_width = 500;
            //信息框的修正
            var _tips_xz = 10;
            //信息框的偏移
            var _tips_offset = (_item_star_x + _bd_item_width * 2);
            //基础的高
            var _base_height = (_item_star_x + _bd_item_height + _qiao_bd_xz + _qiao_height + _bd_kua_xz + _bd_kua_height + _tips_height + _tips_xz + 30);
            //解析
            $.each(data, function (k, v) {
                if (v.list.length == 0) { return; }
                var _tmp_item_x = _item_star_x;
                var _tmp_item_y = _item_star_y;

                //标段矩形list
                var _bd_paper_list = [];
                var _bd_text_list = [];
                var _qiao_list = [];
                var _bd_kua_list = [];
                //跨
                //孔跨
                var _kong_kua = [];
                //解析每个标段
                var _kua_num = 0;
                $.each(v.list, function (ki, vi) {
                    //解析跨
                    var _id_split = vi.id.split('-');
                    var _tmp_kua_num = parseInt(_id_split[3]);

                    //追加一个节段
                    _bd_paper_list.push({ type: "rect", x: _tmp_item_x, y: _tmp_item_y, width: _bd_item_width, height: _bd_item_height });
                    //桥
                    _qiao_list.push({ type: "rect", x: _tmp_item_x, y: (_tmp_item_y + _bd_item_height + _qiao_bd_xz), width: _qiao_width, height: _qiao_height, fill: (vi.status == success ? cfgColor['lev' + vi.lev] : '#fff') });
                    //同时追加text
                    _bd_text_list.push({ text: vi.id, x: _tmp_item_x, y: _tmp_item_y });
                    //第一个
                    if (_kua_num == 0 || _kua_num < _tmp_kua_num) {
                        var _tmp_k_k_s = (parseInt(vi.zs.split('+')[0].replace('K', '')) + parseInt(vi.zs.split('+')[1]));
                        var _tmp_k_k_e = (parseInt(vi.ze.split('+')[0].replace('K', '')) + parseInt(vi.ze.split('+')[1]));
                        var _tmp_kong_kua = (_tmp_k_k_e - _tmp_k_k_s);
                        _kong_kua.push(_tmp_kong_kua);
                        _bd_kua_list.push({ type: "rect", x: (_tmp_item_x - _bd_kua_offset), y: (_tmp_item_y + _bd_item_height + _qiao_height + _qiao_bd_xz + _bd_kua_xz), width: _bd_kua_width, height: _bd_kua_height, fill: '#333' });
                    }
                    //改变x
                    _tmp_item_x = _tmp_item_x + _bd_item_width;
                    _kua_num = _tmp_kua_num;
                });
                //解析每个标段end

                //标段
                paper.add(_bd_paper_list);
                //追加标段text
                $.each(_bd_text_list, function (kt, vt) { paper.text(vt.x + 10, vt.y + 50 * (k + 1) - 50 * (k), vt.text).transform('r270'); });
                //桥
                paper.add(_qiao_list);
                //跨
                paper.add(_bd_kua_list);

                //桥的简介
                paper.rect(_item_star_x, (_item_star_y + _bd_item_height + _qiao_bd_xz + _qiao_height + _bd_kua_xz + _bd_kua_height + 20), _tips_width, _tips_height);
                //桥名
                paper.text(_tips_offset + _item_star_x + 40, (_item_star_y + _bd_item_height + _qiao_bd_xz + _qiao_height + _bd_kua_xz + _bd_kua_height + 40), v.name).attr({ 'font-size': 18 });
                //桩号
                var _zhuang_hao_str = ('桩号:' + v.list[0].zs + '~' + v.list[v.list.length - 1].ze);
                //孔跨
                var _kua_str = '\n孔跨:';
                if (_kua_num > 1) {
                    if (_.uniq(_kong_kua).length == 1) { _kua_str += _kua_num + '×' + _kong_kua[0] + 'm'; }
                    else { _kua_str += _kong_kua.join('m+') + 'm'; }
                }
                else { _kua_str += _kong_kua[0] + 'm'; }
                //标段
                var _biao_duan_str = '\n标段:' + v.bd;
                paper.text(_tips_offset, (_item_star_y + _bd_item_height + _qiao_bd_xz + _qiao_height + _bd_kua_xz + _bd_kua_height + 90), _zhuang_hao_str + _kua_str + _biao_duan_str).attr({ 'font-size': 16, 'text-anchor': 'start' });

                var _tmp_width = (v.list.length * _bd_item_width + _item_star_x);
                //修正宽
                if (_paper_width < _tmp_width) { _paper_width = _tmp_width + 20; paper.setSize(_paper_width, _paper_height); }
                //修正y
                _item_star_y = _base_height * (k + 1); if (_paper_height < _item_star_y) { _paper_height = _item_star_y; paper.setSize(_paper_width, _paper_height); }
            });
            //解析end
        });
        //ajax end
    });
    //搜索end
});
var success = 8;
var cfgColor = { lev1: '#215E21', lev2: '#B5A642', lev3: '#FF7F00', lev4: '#FF00FF', lev5: '#FF0000' };
/*
var data = [{
    name: 'C1标无为堤引桥杨家桥段左幅', bd: 'C1', list: [
        { id: 'C1-Y-1-1-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-1-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-2-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-3-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-4-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-5-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-6-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-7', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
        { id: 'C1-Y-1-7-8', lev: 1, status: 8, zs: 'K15+685', ze: 'K15+865' },
    ]
}, {
    name: 'C2标无为堤引桥杨家桥段左幅', bd: 'C1', list: [
            { id: 'C1-Y-1-1-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
    ]
}, {
    name: 'C2标无为堤引桥杨家桥段左幅', bd: 'C1', list: [
            { id: 'C1-Y-1-1-1', lev: 0, status: 7, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-2', lev: 2, status: 8, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-3', lev: 3, status: 6, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-4', lev: 4, status: 5, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-5', lev: 5, status: 8, zs: 'K15+685', ze: 'K15+865' },
            { id: 'C1-Y-1-1-6', lev: 3, status: 8, zs: 'K15+685', ze: 'K15+865' },
    ]
}];
*/