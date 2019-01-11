﻿(function(){
    $(function () {

        var _personService = abp.services.app.person;

        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find('form');

        //添加联系人功能
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();  //阻止元素发生默认的行为（例如，当点击提交按钮时阻止对表单的提交）。
            //abp验证插件
            if (!_$form.valid()) {
                return;
            }
            var personEditDto = _$form.serializeFormToObject();  //序列化表单为对象

            personEditDto.PhoneNumbers = [];
            var phoneNumber = {};

            phoneNumber.Type = personEditDto.PhoneNumberType;
            phoneNumber.Number = personEditDto.PhoneNumber;
            personEditDto.PhoneNumbers.push(phoneNumber);

            abp.ui.setBusy();

            //约定大于配置
            _personService.createOrUpdatePerson({ personEditDto }).done(function () {
                _$modal.modal('hide');
                location.reload();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        //end add

        //刷新
        $("#RefreshButton").click(function () {
            refreshPersonList();
        });
        function refreshPersonList() {
            location.reload();
        }

        //删除
        $('.delete-person').click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr("data-person-name");
            deletePerson(personId, personName);
        });
        function deletePerson(id, name) {
            abp.message.confirm("是否确认删除姓名为：" + name + "的联系人",
                function (isConfirmed) {
                    if (isConfirmed) {
                        _personService.deletePerson({ id }).done(function () {
                            refreshPersonList();
                        });
                    }
                });
        }

        //编辑
        $(".edit-person").click(function (e) {
            e.preventDefault();
            var personId = $(this).attr("data-person-id");
            _personService.getPersonForEdit({ id: personId }).done(function (data) {
                $("input[name=Id]").val(data.person.id);
                $("input[name=Name]").val(data.person.name).parent().addClass('focused');
                $("input[name=EmailAddress]").val(data.person.emailAddress).parent().addClass('focused');
                $("input[name=PhoneNumber]").val(data.person.phoneNumbers[0].number).parent().addClass('focused');
                $("input[name=PhoneNumberTyper]").selectpicker('val', data.person.phoneNumbers[0].type);
                $("input[name=Address]").val(data.person.address).parent().addClass('focused');
            });
        });

        //取消
        $("#PersonCreateModal").on("hide.bs.modal",function () {
            _$form[0].reset();
            $("input[name=Id]").val('');
        });

    });
})();