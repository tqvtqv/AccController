(function() {
	'use strict';
	var $asm = {};
	global.AccController = global.AccController || {};
	global.AccController.Administration = global.AccController.Administration || {};
	global.AccController.Ais = global.AccController.Ais || {};
	global.AccController.Common = global.AccController.Common || {};
	global.AccController.Email = global.AccController.Email || {};
	global.AccController.Membership = global.AccController.Membership || {};
	global.AccController.Request_Ais = global.AccController.Request_Ais || {};
	ss.initAssembly($asm, 'AccController.Script');
	////////////////////////////////////////////////////////////////////////////////
	// AccController.ScriptInitialization
	var $AccController_ScriptInitialization = function() {
	};
	$AccController_ScriptInitialization.__typeName = 'AccController.ScriptInitialization';
	global.AccController.ScriptInitialization = $AccController_ScriptInitialization;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.LanguageDialog
	var $AccController_Administration_LanguageDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Administration_LanguageDialog.__typeName = 'AccController.Administration.LanguageDialog';
	global.AccController.Administration.LanguageDialog = $AccController_Administration_LanguageDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.LanguageForm
	var $AccController_Administration_LanguageForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Administration_LanguageForm.__typeName = 'AccController.Administration.LanguageForm';
	global.AccController.Administration.LanguageForm = $AccController_Administration_LanguageForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.LanguageGrid
	var $AccController_Administration_LanguageGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Administration_LanguageGrid.__typeName = 'AccController.Administration.LanguageGrid';
	global.AccController.Administration.LanguageGrid = $AccController_Administration_LanguageGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.PermissionCheckEditor
	var $AccController_Administration_PermissionCheckEditor = function(div) {
		this.$containsText = null;
		ss.makeGenericType(Serenity.CheckTreeEditor$1, [Object]).call(this, div, null);
	};
	$AccController_Administration_PermissionCheckEditor.__typeName = 'AccController.Administration.PermissionCheckEditor';
	global.AccController.Administration.PermissionCheckEditor = $AccController_Administration_PermissionCheckEditor;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.PermissionModuleEditor
	var $AccController_Administration_PermissionModuleEditor = function(hidden) {
		ss.makeGenericType(Serenity.Select2Editor$2, [Object, String]).call(this, hidden, null);
		var modules = {};
		var permissions = Q.getRemoteData('Administration.PermissionKeys').Entities;
		for (var i = 0; i < permissions.length; i++) {
			var k = permissions[i];
			var idx1 = k.indexOf(String.fromCharCode(58));
			if (idx1 <= 0) {
				continue;
			}
			var idx2 = k.indexOf(String.fromCharCode(58), idx1 + 1);
			if (idx2 <= 0) {
				continue;
			}
			var module = k.substr(0, idx1);
			modules[module] = true;
		}
		var othersModule = false;
		for (var $t1 = 0; $t1 < permissions.length; $t1++) {
			var k1 = permissions[$t1];
			var idx11 = k1.indexOf(String.fromCharCode(58));
			if (idx11 < 0 && !ss.isValue(modules[k1])) {
				othersModule = true;
				break;
			}
		}
		var moduleList = [];
		ss.arrayAddRange(moduleList, Object.keys(modules));
		if (othersModule) {
			moduleList.push('Common');
		}
		for (var $t2 = 0; $t2 < moduleList.length; $t2++) {
			var k2 = moduleList[$t2];
			this.addItem(k2, k2, k2, false);
		}
	};
	$AccController_Administration_PermissionModuleEditor.__typeName = 'AccController.Administration.PermissionModuleEditor';
	global.AccController.Administration.PermissionModuleEditor = $AccController_Administration_PermissionModuleEditor;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.RoleCheckEditor
	var $AccController_Administration_RoleCheckEditor = function(div) {
		this.$containsText = null;
		ss.makeGenericType(Serenity.CheckTreeEditor$1, [Object]).call(this, div, null);
	};
	$AccController_Administration_RoleCheckEditor.__typeName = 'AccController.Administration.RoleCheckEditor';
	global.AccController.Administration.RoleCheckEditor = $AccController_Administration_RoleCheckEditor;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.RoleDialog
	var $AccController_Administration_RoleDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Administration_RoleDialog.__typeName = 'AccController.Administration.RoleDialog';
	global.AccController.Administration.RoleDialog = $AccController_Administration_RoleDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.RoleForm
	var $AccController_Administration_RoleForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Administration_RoleForm.__typeName = 'AccController.Administration.RoleForm';
	global.AccController.Administration.RoleForm = $AccController_Administration_RoleForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.RoleGrid
	var $AccController_Administration_RoleGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Administration_RoleGrid.__typeName = 'AccController.Administration.RoleGrid';
	global.AccController.Administration.RoleGrid = $AccController_Administration_RoleGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.RolePermissionDialog
	var $AccController_Administration_RolePermissionDialog = function(opt) {
		this.$permissions = null;
		ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).$ctor1.call(this, opt);
		this.$permissions = new $AccController_Administration_PermissionCheckEditor(this.byId$1('Permissions'));
		Q.serviceRequest('Administration/RolePermission/List', { RoleID: this.options.roleID, Module: null, Submodule: null }, ss.mkdel(this, function(response) {
			this.$permissions.set_value(response.Entities);
		}), null);
	};
	$AccController_Administration_RolePermissionDialog.__typeName = 'AccController.Administration.RolePermissionDialog';
	global.AccController.Administration.RolePermissionDialog = $AccController_Administration_RolePermissionDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.TranslationGrid
	var $AccController_Administration_TranslationGrid = function(container) {
		this.$searchText = null;
		this.$sourceLanguage = null;
		this.$targetLanguage = null;
		this.$targetLanguageKey = null;
		this.$hasChanges = false;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.element.on('keyup.' + this.uniqueName + ' change.' + this.uniqueName, 'input.custom-text', ss.mkdel(this, function(e) {
			var value = Q.trimToNull($(e.target).val());
			if (value === '') {
				value = null;
			}
			this.view.getItemById($(e.target).data('key')).CustomText = value;
			this.$hasChanges = true;
		}));
	};
	$AccController_Administration_TranslationGrid.__typeName = 'AccController.Administration.TranslationGrid';
	global.AccController.Administration.TranslationGrid = $AccController_Administration_TranslationGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.UserDialog
	var $AccController_Administration_UserDialog = function() {
		this.$form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		var request = {};
		Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
			var obj = response;
			var t = obj;
			$AccController_Administration_UserDialog.$user_name = t.Username;
			$AccController_Administration_UserDialog.$admin_lv = ss.cast(obj.adminlv, String);
			//Q.Log("user_name:  " + user_name + "  admin_lv:" + admin_lv);
			if ($AccController_Administration_UserDialog.$i_refresh === 1) {
				$AccController_Administration_UserDialog.$i_refresh = 0;
				this.reloadById();
			}
		}) });
		this.$form = new $AccController_Administration_UserForm(this.get_idPrefix());
		Serenity.VX.addValidationRule(this.$form.get_password(), this.uniqueName, ss.mkdel(this, function(e) {
			if (this.$form.get_password().get_value().length < 7) {
				return 'Password must be at least 7 characters!';
			}
			return null;
		}));
		Serenity.VX.addValidationRule(this.$form.get_passwordConfirm(), this.uniqueName, ss.mkdel(this, function(e1) {
			if (!ss.referenceEquals(this.$form.get_password().get_value(), this.$form.get_passwordConfirm().get_value())) {
				return "The passwords entered doesn't match!";
			}
			return null;
		}));
	};
	$AccController_Administration_UserDialog.__typeName = 'AccController.Administration.UserDialog';
	global.AccController.Administration.UserDialog = $AccController_Administration_UserDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.UserForm
	var $AccController_Administration_UserForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Administration_UserForm.__typeName = 'AccController.Administration.UserForm';
	global.AccController.Administration.UserForm = $AccController_Administration_UserForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.UserGrid
	var $AccController_Administration_UserGrid = function(container) {
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Administration_UserGrid.__typeName = 'AccController.Administration.UserGrid';
	global.AccController.Administration.UserGrid = $AccController_Administration_UserGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.UserPermissionDialog
	var $AccController_Administration_UserPermissionDialog = function(opt) {
		this.$permissions = null;
		ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).$ctor1.call(this, opt);
		this.$permissions = new $AccController_Administration_PermissionCheckEditor(this.byId$1('Permissions'));
		Q.serviceRequest('Administration/UserPermission/List', { UserID: this.options.userID, Module: null, Submodule: null }, ss.mkdel(this, function(response) {
			this.$permissions.set_value(response.Entities);
		}), null);
	};
	$AccController_Administration_UserPermissionDialog.__typeName = 'AccController.Administration.UserPermissionDialog';
	global.AccController.Administration.UserPermissionDialog = $AccController_Administration_UserPermissionDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Administration.UserRoleDialog
	var $AccController_Administration_UserRoleDialog = function(opt) {
		this.$permissions = null;
		ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).$ctor1.call(this, opt);
		this.$permissions = new $AccController_Administration_RoleCheckEditor(this.byId$1('Roles'));
		Q.serviceRequest('Administration/UserRole/List', { UserID: this.options.userID }, ss.mkdel(this, function(response) {
			this.$permissions.set_value(Enumerable.from(response.Entities).select(function(x) {
				return x.toString();
			}).toArray());
		}), null);
	};
	$AccController_Administration_UserRoleDialog.__typeName = 'AccController.Administration.UserRoleDialog';
	global.AccController.Administration.UserRoleDialog = $AccController_Administration_UserRoleDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisAddOUDialog
	var $AccController_Ais_AisAddOUDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisAddOUDialog.__typeName = 'AccController.Ais.AisAddOUDialog';
	global.AccController.Ais.AisAddOUDialog = $AccController_Ais_AisAddOUDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisAddOUForm
	var $AccController_Ais_AisAddOUForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisAddOUForm.__typeName = 'AccController.Ais.AisAddOUForm';
	global.AccController.Ais.AisAddOUForm = $AccController_Ais_AisAddOUForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisAddOUGrid
	var $AccController_Ais_AisAddOUGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Ais_AisAddOUGrid.__typeName = 'AccController.Ais.AisAddOUGrid';
	global.AccController.Ais.AisAddOUGrid = $AccController_Ais_AisAddOUGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileDialog
	var $AccController_Ais_AisFileDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisFileDialog.__typeName = 'AccController.Ais.AisFileDialog';
	global.AccController.Ais.AisFileDialog = $AccController_Ais_AisFileDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileForm
	var $AccController_Ais_AisFileForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisFileForm.__typeName = 'AccController.Ais.AisFileForm';
	global.AccController.Ais.AisFileForm = $AccController_Ais_AisFileForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileGrid
	var $AccController_Ais_AisFileGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Ais_AisFileGrid.__typeName = 'AccController.Ais.AisFileGrid';
	global.AccController.Ais.AisFileGrid = $AccController_Ais_AisFileGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileResultsDialog
	var $AccController_Ais_AisFileResultsDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisFileResultsDialog.__typeName = 'AccController.Ais.AisFileResultsDialog';
	global.AccController.Ais.AisFileResultsDialog = $AccController_Ais_AisFileResultsDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileResultsForm
	var $AccController_Ais_AisFileResultsForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisFileResultsForm.__typeName = 'AccController.Ais.AisFileResultsForm';
	global.AccController.Ais.AisFileResultsForm = $AccController_Ais_AisFileResultsForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisFileResultsGrid
	var $AccController_Ais_AisFileResultsGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Ais_AisFileResultsGrid.__typeName = 'AccController.Ais.AisFileResultsGrid';
	global.AccController.Ais.AisFileResultsGrid = $AccController_Ais_AisFileResultsGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisLogDialog
	var $AccController_Ais_AisLogDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisLogDialog.__typeName = 'AccController.Ais.AisLogDialog';
	global.AccController.Ais.AisLogDialog = $AccController_Ais_AisLogDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisLogForm
	var $AccController_Ais_AisLogForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisLogForm.__typeName = 'AccController.Ais.AisLogForm';
	global.AccController.Ais.AisLogForm = $AccController_Ais_AisLogForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisLogGrid
	var $AccController_Ais_AisLogGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Ais_AisLogGrid.__typeName = 'AccController.Ais.AisLogGrid';
	global.AccController.Ais.AisLogGrid = $AccController_Ais_AisLogGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeInfoDialog
	var $AccController_Ais_AisUserChangeInfoDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisUserChangeInfoDialog.__typeName = 'AccController.Ais.AisUserChangeInfoDialog';
	global.AccController.Ais.AisUserChangeInfoDialog = $AccController_Ais_AisUserChangeInfoDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeInfoForm
	var $AccController_Ais_AisUserChangeInfoForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisUserChangeInfoForm.__typeName = 'AccController.Ais.AisUserChangeInfoForm';
	global.AccController.Ais.AisUserChangeInfoForm = $AccController_Ais_AisUserChangeInfoForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeInfoGrid
	var $AccController_Ais_AisUserChangeInfoGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Ais_AisUserChangeInfoGrid.__typeName = 'AccController.Ais.AisUserChangeInfoGrid';
	global.AccController.Ais.AisUserChangeInfoGrid = $AccController_Ais_AisUserChangeInfoGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeOUDialog
	var $AccController_Ais_AisUserChangeOUDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisUserChangeOUDialog.__typeName = 'AccController.Ais.AisUserChangeOUDialog';
	global.AccController.Ais.AisUserChangeOUDialog = $AccController_Ais_AisUserChangeOUDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeOUForm
	var $AccController_Ais_AisUserChangeOUForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisUserChangeOUForm.__typeName = 'AccController.Ais.AisUserChangeOUForm';
	global.AccController.Ais.AisUserChangeOUForm = $AccController_Ais_AisUserChangeOUForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserChangeOUGrid
	var $AccController_Ais_AisUserChangeOUGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Ais_AisUserChangeOUGrid.__typeName = 'AccController.Ais.AisUserChangeOUGrid';
	global.AccController.Ais.AisUserChangeOUGrid = $AccController_Ais_AisUserChangeOUGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserDialog
	var $AccController_Ais_AisUserDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_AisUserDialog.__typeName = 'AccController.Ais.AisUserDialog';
	global.AccController.Ais.AisUserDialog = $AccController_Ais_AisUserDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserForm
	var $AccController_Ais_AisUserForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_AisUserForm.__typeName = 'AccController.Ais.AisUserForm';
	global.AccController.Ais.AisUserForm = $AccController_Ais_AisUserForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.AisUserGrid
	var $AccController_Ais_AisUserGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Ais_AisUserGrid.__typeName = 'AccController.Ais.AisUserGrid';
	global.AccController.Ais.AisUserGrid = $AccController_Ais_AisUserGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.GroupDialog
	var $AccController_Ais_GroupDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Ais_GroupDialog.__typeName = 'AccController.Ais.GroupDialog';
	global.AccController.Ais.GroupDialog = $AccController_Ais_GroupDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.GroupForm
	var $AccController_Ais_GroupForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_GroupForm.__typeName = 'AccController.Ais.GroupForm';
	global.AccController.Ais.GroupForm = $AccController_Ais_GroupForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.GroupGrid
	var $AccController_Ais_GroupGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Ais_GroupGrid.__typeName = 'AccController.Ais.GroupGrid';
	global.AccController.Ais.GroupGrid = $AccController_Ais_GroupGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.TesttDialog
	var $AccController_Ais_TesttDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Ais_TesttForm(this.get_idPrefix());
	};
	$AccController_Ais_TesttDialog.__typeName = 'AccController.Ais.TesttDialog';
	global.AccController.Ais.TesttDialog = $AccController_Ais_TesttDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.TesttForm
	var $AccController_Ais_TesttForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Ais_TesttForm.__typeName = 'AccController.Ais.TesttForm';
	global.AccController.Ais.TesttForm = $AccController_Ais_TesttForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Ais.TesttGrid
	var $AccController_Ais_TesttGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Ais_TesttGrid.__typeName = 'AccController.Ais.TesttGrid';
	global.AccController.Ais.TesttGrid = $AccController_Ais_TesttGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Common.GridEditorBase
	var $AccController_Common_GridEditorBase$1 = function(TEntity) {
		var $type = function(container) {
			this.$nextId = 1;
			ss.makeGenericType(Serenity.EntityGrid$1, [TEntity]).call(this, container);
		};
		ss.registerGenericClassInstance($type, $AccController_Common_GridEditorBase$1, [TEntity], {
			id: function(entity) {
				return ss.cast(entity.__id, ss.Int32);
			},
			save: function(opt, callback) {
				var request = opt.request;
				var row = Q$Externals.deepClone(request.Entity);
				var id = ss.cast(row.__id, ss.Int32);
				if (ss.isNullOrUndefined(id)) {
					row.__id = this.$nextId++;
				}
				if (!this.validateEntity(row, id)) {
					return;
				}
				var items = ss.arrayClone(this.view.getItems());
				if (ss.isNullOrUndefined(id)) {
					items.push(row);
				}
				else {
					var index = Enumerable.from(items).indexOf(ss.mkdel(this, function(x) {
						return this.id(x) === ss.unbox(id);
					}));
					items[index] = row;
				}
				this.setEntities(items);
				callback({});
			},
			deleteEntity: function(id) {
				this.view.deleteItem(id);
				return true;
			},
			validateEntity: function(row, id) {
				return true;
			},
			setEntities: function(items) {
				this.view.setItems(items, true);
			},
			getNewEntity: function() {
				return ss.createInstance(TEntity);
			},
			getButtons: function() {
				var $t1 = [];
				$t1.push({ title: this.getAddButtonCaption(), cssClass: 'add-button', onClick: ss.mkdel(this, function() {
					this.createEntityDialog(this.getItemType(), ss.mkdel(this, function(dlg) {
						var dialog = ss.cast(dlg, ss.makeGenericType($AccController_Common_GridEditorDialog$1, [TEntity]));
						dialog.set_onSave(ss.mkdel(this, this.save));
						dialog.loadEntityAndOpenDialog(this.getNewEntity());
					}));
				}) });
				return $t1;
			},
			editItem: function(entityOrId) {
				var id = ss.unbox(Serenity.IdExtensions.toInt32(entityOrId));
				var item = this.view.getItemById(id);
				this.createEntityDialog(this.getItemType(), ss.mkdel(this, function(dlg) {
					var dialog = ss.cast(dlg, ss.makeGenericType($AccController_Common_GridEditorDialog$1, [TEntity]));
					dialog.set_onDelete(ss.mkdel(this, function(opt, callback) {
						if (!this.deleteEntity(id)) {
							return;
						}
						callback({});
					}));
					dialog.set_onSave(ss.mkdel(this, this.save));
					dialog.loadEntityAndOpenDialog(item);
				}));
			},
			getEditValue: function(property, target) {
				target[property.name] = this.get_value();
			},
			setEditValue: function(source, property) {
				this.set_value(ss.cast(source[property.name], Array));
			},
			get_value: function() {
				return Enumerable.from(this.view.getItems()).select(function(x) {
					var y = Q$Externals.deepClone(x);
					delete y['__id'];
					return y;
				}).toArray();
			},
			set_value: function(value) {
				this.view.setItems(Enumerable.from(value || []).select(ss.mkdel(this, function(x) {
					var y = Q$Externals.deepClone(x);
					y.__id = this.$nextId++;
					return y;
				})).toArray(), true);
			},
			getGridCanLoad: function() {
				return false;
			},
			usePager: function() {
				return false;
			},
			getInitialTitle: function() {
				return null;
			},
			createQuickSearchInput: function() {
			}
		}, function() {
			return ss.makeGenericType(Serenity.EntityGrid$1, [TEntity]);
		}, function() {
			return [Serenity.IDataGrid, Serenity.ISetEditValue, Serenity.IGetEditValue];
		});
		ss.setMetadata($type, { attr: [new Serenity.ElementAttribute('<div/>'), new Serenity.EditorAttribute(), new Serenity.IdPropertyAttribute('__id')] });
		return $type;
	};
	$AccController_Common_GridEditorBase$1.__typeName = 'AccController.Common.GridEditorBase$1';
	ss.initGenericClass($AccController_Common_GridEditorBase$1, $asm, 1);
	global.AccController.Common.GridEditorBase$1 = $AccController_Common_GridEditorBase$1;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Common.GridEditorDialog
	var $AccController_Common_GridEditorDialog$1 = function(TEntity) {
		var $type = function() {
			this.$8$OnSaveField = null;
			this.$8$OnDeleteField = null;
			ss.makeGenericType(Serenity.EntityDialog$1, [TEntity]).call(this);
		};
		ss.registerGenericClassInstance($type, $AccController_Common_GridEditorDialog$1, [TEntity], {
			destroy: function() {
				this.set_onSave(null);
				this.set_onDelete(null);
				ss.makeGenericType(Serenity.EntityDialog$2, [TEntity, Object]).prototype.destroy.call(this);
			},
			updateInterface: function() {
				ss.makeGenericType(Serenity.EntityDialog$2, [TEntity, Object]).prototype.updateInterface.call(this);
				// apply changes button doesn't work properly with in-memory grids yet
				if (ss.isValue(this.applyChangesButton)) {
					this.applyChangesButton.hide();
				}
			},
			saveHandler: function(options, callback) {
				if (!ss.staticEquals(this.get_onSave(), null)) {
					this.get_onSave()(options, callback);
				}
			},
			deleteHandler: function(options, callback) {
				if (!ss.staticEquals(this.get_onDelete(), null)) {
					this.get_onDelete()(options, callback);
				}
			},
			get_onSave: function() {
				return this.$8$OnSaveField;
			},
			set_onSave: function(value) {
				this.$8$OnSaveField = value;
			},
			get_onDelete: function() {
				return this.$8$OnDeleteField;
			},
			set_onDelete: function(value) {
				this.$8$OnDeleteField = value;
			}
		}, function() {
			return ss.makeGenericType(Serenity.EntityDialog$1, [TEntity]);
		}, function() {
			return [Serenity.IDialog, Serenity.IEditDialog];
		});
		ss.setMetadata($type, { attr: [new Serenity.IdPropertyAttribute('__id')] });
		return $type;
	};
	$AccController_Common_GridEditorDialog$1.__typeName = 'AccController.Common.GridEditorDialog$1';
	ss.initGenericClass($AccController_Common_GridEditorDialog$1, $asm, 1);
	global.AccController.Common.GridEditorDialog$1 = $AccController_Common_GridEditorDialog$1;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Common.LanguageSelection
	var $AccController_Common_LanguageSelection = function(hidden, currentLanguage) {
		this.$currentLanguage = null;
		ss.makeGenericType(Serenity.LookupEditorBase$1, [Object]).call(this, hidden);
		this.$currentLanguage = ss.coalesce(currentLanguage, 'en');
		this.set_value('en');
		var self = this;
		Serenity.WX.changeSelect2(this, function(e) {
			$.cookie('LanguagePreference', self.get_value(), { path: Q$Config.applicationPath });
			window.location.reload(true);
		});
	};
	$AccController_Common_LanguageSelection.__typeName = 'AccController.Common.LanguageSelection';
	global.AccController.Common.LanguageSelection = $AccController_Common_LanguageSelection;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Common.SidebarSearch
	var $AccController_Common_SidebarSearch = function(input, menuUL) {
		this.$menuUL = null;
		Serenity.Widget.call(this, input);
		var self = this;
		var $t1 = Serenity.QuickSearchInputOptions.$ctor();
		$t1.onSearch = function(field, text, success) {
			self.$updateMatchFlags(text);
			success(true);
		};
		new Serenity.QuickSearchInput(input, $t1);
		this.$menuUL = menuUL;
	};
	$AccController_Common_SidebarSearch.__typeName = 'AccController.Common.SidebarSearch';
	global.AccController.Common.SidebarSearch = $AccController_Common_SidebarSearch;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailChangeDialog
	var $AccController_Email_EmailChangeDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailChangeDialog.__typeName = 'AccController.Email.EmailChangeDialog';
	global.AccController.Email.EmailChangeDialog = $AccController_Email_EmailChangeDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailChangeForm
	var $AccController_Email_EmailChangeForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailChangeForm.__typeName = 'AccController.Email.EmailChangeForm';
	global.AccController.Email.EmailChangeForm = $AccController_Email_EmailChangeForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailChangeGrid
	var $AccController_Email_EmailChangeGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Email_EmailChangeGrid.__typeName = 'AccController.Email.EmailChangeGrid';
	global.AccController.Email.EmailChangeGrid = $AccController_Email_EmailChangeGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailFileDialog
	var $AccController_Email_EmailFileDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailFileDialog.__typeName = 'AccController.Email.EmailFileDialog';
	global.AccController.Email.EmailFileDialog = $AccController_Email_EmailFileDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailFileForm
	var $AccController_Email_EmailFileForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailFileForm.__typeName = 'AccController.Email.EmailFileForm';
	global.AccController.Email.EmailFileForm = $AccController_Email_EmailFileForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailFileGrid
	var $AccController_Email_EmailFileGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Email_EmailFileGrid.__typeName = 'AccController.Email.EmailFileGrid';
	global.AccController.Email.EmailFileGrid = $AccController_Email_EmailFileGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupAccountDialog
	var $AccController_Email_EmailGroupAccountDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailGroupAccountDialog.__typeName = 'AccController.Email.EmailGroupAccountDialog';
	global.AccController.Email.EmailGroupAccountDialog = $AccController_Email_EmailGroupAccountDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupAccountForm
	var $AccController_Email_EmailGroupAccountForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailGroupAccountForm.__typeName = 'AccController.Email.EmailGroupAccountForm';
	global.AccController.Email.EmailGroupAccountForm = $AccController_Email_EmailGroupAccountForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupAccountGrid
	var $AccController_Email_EmailGroupAccountGrid = function(container) {
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Email_EmailGroupAccountGrid.__typeName = 'AccController.Email.EmailGroupAccountGrid';
	global.AccController.Email.EmailGroupAccountGrid = $AccController_Email_EmailGroupAccountGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupDialog
	var $AccController_Email_EmailGroupDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailGroupDialog.__typeName = 'AccController.Email.EmailGroupDialog';
	global.AccController.Email.EmailGroupDialog = $AccController_Email_EmailGroupDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupForm
	var $AccController_Email_EmailGroupForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailGroupForm.__typeName = 'AccController.Email.EmailGroupForm';
	global.AccController.Email.EmailGroupForm = $AccController_Email_EmailGroupForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailGroupGrid
	var $AccController_Email_EmailGroupGrid = function(container) {
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Email_EmailGroupGrid.__typeName = 'AccController.Email.EmailGroupGrid';
	global.AccController.Email.EmailGroupGrid = $AccController_Email_EmailGroupGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailLogDialog
	var $AccController_Email_EmailLogDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailLogDialog.__typeName = 'AccController.Email.EmailLogDialog';
	global.AccController.Email.EmailLogDialog = $AccController_Email_EmailLogDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailLogForm
	var $AccController_Email_EmailLogForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailLogForm.__typeName = 'AccController.Email.EmailLogForm';
	global.AccController.Email.EmailLogForm = $AccController_Email_EmailLogForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailLogGrid
	var $AccController_Email_EmailLogGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Email_EmailLogGrid.__typeName = 'AccController.Email.EmailLogGrid';
	global.AccController.Email.EmailLogGrid = $AccController_Email_EmailLogGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailNewDialog
	var $AccController_Email_EmailNewDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailNewDialog.__typeName = 'AccController.Email.EmailNewDialog';
	global.AccController.Email.EmailNewDialog = $AccController_Email_EmailNewDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailNewForm
	var $AccController_Email_EmailNewForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailNewForm.__typeName = 'AccController.Email.EmailNewForm';
	global.AccController.Email.EmailNewForm = $AccController_Email_EmailNewForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailNewGrid
	var $AccController_Email_EmailNewGrid = function(container) {
		this.$uploader = null;
		this.$rowSelection = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Email_EmailNewGrid.__typeName = 'AccController.Email.EmailNewGrid';
	global.AccController.Email.EmailNewGrid = $AccController_Email_EmailNewGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailUpdateInfoDialog
	var $AccController_Email_EmailUpdateInfoDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_EmailUpdateInfoDialog.__typeName = 'AccController.Email.EmailUpdateInfoDialog';
	global.AccController.Email.EmailUpdateInfoDialog = $AccController_Email_EmailUpdateInfoDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailUpdateInfoForm
	var $AccController_Email_EmailUpdateInfoForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_EmailUpdateInfoForm.__typeName = 'AccController.Email.EmailUpdateInfoForm';
	global.AccController.Email.EmailUpdateInfoForm = $AccController_Email_EmailUpdateInfoForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.EmailUpdateInfoGrid
	var $AccController_Email_EmailUpdateInfoGrid = function(container) {
		this.$rowSelection = null;
		this.$uploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
		this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
	};
	$AccController_Email_EmailUpdateInfoGrid.__typeName = 'AccController.Email.EmailUpdateInfoGrid';
	global.AccController.Email.EmailUpdateInfoGrid = $AccController_Email_EmailUpdateInfoGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.FileResultDialog
	var $AccController_Email_FileResultDialog = function() {
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
	};
	$AccController_Email_FileResultDialog.__typeName = 'AccController.Email.FileResultDialog';
	global.AccController.Email.FileResultDialog = $AccController_Email_FileResultDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.FileResultForm
	var $AccController_Email_FileResultForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Email_FileResultForm.__typeName = 'AccController.Email.FileResultForm';
	global.AccController.Email.FileResultForm = $AccController_Email_FileResultForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Email.FileResultGrid
	var $AccController_Email_FileResultGrid = function(container) {
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Email_FileResultGrid.__typeName = 'AccController.Email.FileResultGrid';
	global.AccController.Email.FileResultGrid = $AccController_Email_FileResultGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Membership.LoginForm
	var $AccController_Membership_LoginForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Membership_LoginForm.__typeName = 'AccController.Membership.LoginForm';
	global.AccController.Membership.LoginForm = $AccController_Membership_LoginForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Membership.LoginPanel
	var $AccController_Membership_LoginPanel = function() {
		ss.makeGenericType(Serenity.PropertyDialog$1, [Object]).call(this);
		this.byId$1('LoginButton').click(ss.thisFix(ss.mkdel(this, function(s, e) {
			e.preventDefault();
			if (!this.validateForm()) {
				return;
			}
			var request = this.getSaveEntity();
			Q.serviceCall({
				url: Q.resolveUrl('~/Account/Login'),
				request: request,
				onSuccess: function(response) {
					var q = Q$Externals.parseQueryString();
					var $t1 = q['returnUrl'];
					if (ss.isNullOrUndefined($t1)) {
						$t1 = q['ReturnUrl'];
					}
					var r = $t1;
					if (!ss.isNullOrEmptyString(r)) {
						window.location.href = r;
					}
					else {
						window.location.href = Q.resolveUrl('~/');
					}
				}
			});
		})));
	};
	$AccController_Membership_LoginPanel.__typeName = 'AccController.Membership.LoginPanel';
	global.AccController.Membership.LoginPanel = $AccController_Membership_LoginPanel;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Membership.RegisterForm
	var $AccController_Membership_RegisterForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Membership_RegisterForm.__typeName = 'AccController.Membership.RegisterForm';
	global.AccController.Membership.RegisterForm = $AccController_Membership_RegisterForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Membership.RegisterPanel
	var $AccController_Membership_RegisterPanel = function() {
		ss.makeGenericType(Serenity.PropertyDialog$1, [Object]).call(this);
		this.byId$1('RegisterButton').click(ss.thisFix(ss.mkdel(this, function(s, e) {
			e.preventDefault();
			if (!this.validateForm()) {
				return;
			}
			var request = this.getSaveEntity();
			Q.serviceCall({
				url: Q.resolveUrl('~/Account/Register'),
				request: request,
				onSuccess: function(response) {
					window.location.href = Q.resolveUrl('~/');
				}
			});
		})));
	};
	$AccController_Membership_RegisterPanel.__typeName = 'AccController.Membership.RegisterPanel';
	global.AccController.Membership.RegisterPanel = $AccController_Membership_RegisterPanel;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisAddOUDialog
	var $AccController_Request_Ais_AisAddOUDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Request_Ais_AisAddOUForm(this.get_idPrefix());
	};
	$AccController_Request_Ais_AisAddOUDialog.__typeName = 'AccController.Request_Ais.AisAddOUDialog';
	global.AccController.Request_Ais.AisAddOUDialog = $AccController_Request_Ais_AisAddOUDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisAddOUForm
	var $AccController_Request_Ais_AisAddOUForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Request_Ais_AisAddOUForm.__typeName = 'AccController.Request_Ais.AisAddOUForm';
	global.AccController.Request_Ais.AisAddOUForm = $AccController_Request_Ais_AisAddOUForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisAddOUGrid
	var $AccController_Request_Ais_AisAddOUGrid = function(container) {
		this.$resultUploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Request_Ais_AisAddOUGrid.__typeName = 'AccController.Request_Ais.AisAddOUGrid';
	global.AccController.Request_Ais.AisAddOUGrid = $AccController_Request_Ais_AisAddOUGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeInfoDialog
	var $AccController_Request_Ais_AisUserChangeInfoDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Request_Ais_AisUserChangeInfoForm(this.get_idPrefix());
	};
	$AccController_Request_Ais_AisUserChangeInfoDialog.__typeName = 'AccController.Request_Ais.AisUserChangeInfoDialog';
	global.AccController.Request_Ais.AisUserChangeInfoDialog = $AccController_Request_Ais_AisUserChangeInfoDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeInfoForm
	var $AccController_Request_Ais_AisUserChangeInfoForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Request_Ais_AisUserChangeInfoForm.__typeName = 'AccController.Request_Ais.AisUserChangeInfoForm';
	global.AccController.Request_Ais.AisUserChangeInfoForm = $AccController_Request_Ais_AisUserChangeInfoForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeInfoGrid
	var $AccController_Request_Ais_AisUserChangeInfoGrid = function(container) {
		this.$resultUploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Request_Ais_AisUserChangeInfoGrid.__typeName = 'AccController.Request_Ais.AisUserChangeInfoGrid';
	global.AccController.Request_Ais.AisUserChangeInfoGrid = $AccController_Request_Ais_AisUserChangeInfoGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeOUDialog
	var $AccController_Request_Ais_AisUserChangeOUDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Request_Ais_AisUserChangeOUForm(this.get_idPrefix());
	};
	$AccController_Request_Ais_AisUserChangeOUDialog.__typeName = 'AccController.Request_Ais.AisUserChangeOUDialog';
	global.AccController.Request_Ais.AisUserChangeOUDialog = $AccController_Request_Ais_AisUserChangeOUDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeOUForm
	var $AccController_Request_Ais_AisUserChangeOUForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Request_Ais_AisUserChangeOUForm.__typeName = 'AccController.Request_Ais.AisUserChangeOUForm';
	global.AccController.Request_Ais.AisUserChangeOUForm = $AccController_Request_Ais_AisUserChangeOUForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserChangeOUGrid
	var $AccController_Request_Ais_AisUserChangeOUGrid = function(container) {
		this.$resultUploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Request_Ais_AisUserChangeOUGrid.__typeName = 'AccController.Request_Ais.AisUserChangeOUGrid';
	global.AccController.Request_Ais.AisUserChangeOUGrid = $AccController_Request_Ais_AisUserChangeOUGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserDialog
	var $AccController_Request_Ais_AisUserDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Request_Ais_AisUserForm(this.get_idPrefix());
	};
	$AccController_Request_Ais_AisUserDialog.__typeName = 'AccController.Request_Ais.AisUserDialog';
	global.AccController.Request_Ais.AisUserDialog = $AccController_Request_Ais_AisUserDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserForm
	var $AccController_Request_Ais_AisUserForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Request_Ais_AisUserForm.__typeName = 'AccController.Request_Ais.AisUserForm';
	global.AccController.Request_Ais.AisUserForm = $AccController_Request_Ais_AisUserForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.AisUserGrid
	var $AccController_Request_Ais_AisUserGrid = function(container) {
		this.$resultUploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Request_Ais_AisUserGrid.__typeName = 'AccController.Request_Ais.AisUserGrid';
	global.AccController.Request_Ais.AisUserGrid = $AccController_Request_Ais_AisUserGrid;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.GroupDialog
	var $AccController_Request_Ais_GroupDialog = function() {
		this.form = null;
		ss.makeGenericType(Serenity.EntityDialog$1, [Object]).call(this);
		this.form = new $AccController_Request_Ais_GroupForm(this.get_idPrefix());
	};
	$AccController_Request_Ais_GroupDialog.__typeName = 'AccController.Request_Ais.GroupDialog';
	global.AccController.Request_Ais.GroupDialog = $AccController_Request_Ais_GroupDialog;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.GroupForm
	var $AccController_Request_Ais_GroupForm = function(idPrefix) {
		Serenity.PrefixedContext.call(this, idPrefix);
	};
	$AccController_Request_Ais_GroupForm.__typeName = 'AccController.Request_Ais.GroupForm';
	global.AccController.Request_Ais.GroupForm = $AccController_Request_Ais_GroupForm;
	////////////////////////////////////////////////////////////////////////////////
	// AccController.Request_Ais.GroupGrid
	var $AccController_Request_Ais_GroupGrid = function(container) {
		this.$resultUploader = null;
		ss.makeGenericType(Serenity.EntityGrid$1, [Object]).call(this, container);
	};
	$AccController_Request_Ais_GroupGrid.__typeName = 'AccController.Request_Ais.GroupGrid';
	global.AccController.Request_Ais.GroupGrid = $AccController_Request_Ais_GroupGrid;
	ss.initClass($AccController_ScriptInitialization, $asm, {});
	ss.initClass($AccController_Administration_LanguageDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog, Serenity.IAsyncInit]);
	ss.initClass($AccController_Administration_LanguageForm, $asm, {
		get_languageId: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LanguageId');
		},
		get_languageName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LanguageName');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Administration_LanguageGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid, Serenity.IAsyncInit]);
	ss.initClass($AccController_Administration_PermissionCheckEditor, $asm, {
		getButtons: function() {
			return [];
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.get_element(), ss.mkdel(this, function(field, text) {
				this.$containsText = Q.trimToNull(text);
				this.view.setItems(this.view.getItems(), true);
			}), null);
		},
		onViewFilter: function(item) {
			if (!ss.makeGenericType(Serenity.CheckTreeEditor$2, [Object, Object]).prototype.onViewFilter.call(this, item)) {
				return false;
			}
			var contains = Select2.util.stripDiacritics(ss.coalesce(this.$containsText, '')).toUpperCase();
			if (Q.isEmptyOrNull(contains)) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.text, '')).toUpperCase().indexOf(contains) !== -1) {
				return true;
			}
			return false;
		},
		getItems: function() {
			var list = [];
			var permissions = Q.getRemoteData('Administration.PermissionKeys').Entities;
			var permissionTitles = {};
			for (var i = 0; i < permissions.length; i++) {
				var p = permissions[i];
				permissionTitles[p] = ss.coalesce(Q.tryGetText('Permission.' + p), p);
			}
			permissions.sort(function(x, y) {
				return Q$Externals.turkishLocaleCompare(permissionTitles[x], permissionTitles[y]);
			});
			for (var $t1 = 0; $t1 < permissions.length; $t1++) {
				var permission = permissions[$t1];
				list.push({ id: permission, text: permissionTitles[permission] });
			}
			return list;
		}
	}, ss.makeGenericType(Serenity.CheckTreeEditor$1, [Object]), [Serenity.IDataGrid, Serenity.IGetEditValue, Serenity.ISetEditValue]);
	ss.initClass($AccController_Administration_PermissionModuleEditor, $asm, {}, ss.makeGenericType(Serenity.Select2Editor$2, [Object, String]), [Serenity.IStringValue]);
	ss.initClass($AccController_Administration_RoleCheckEditor, $asm, {
		getButtons: function() {
			return [];
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.get_element(), ss.mkdel(this, function(field, text) {
				this.$containsText = Q.trimToNull(text);
				this.view.setItems(this.view.getItems(), true);
			}), null);
		},
		onViewFilter: function(item) {
			if (!ss.makeGenericType(Serenity.CheckTreeEditor$2, [Object, Object]).prototype.onViewFilter.call(this, item)) {
				return false;
			}
			var contains = Select2.util.stripDiacritics(ss.coalesce(this.$containsText, '')).toUpperCase();
			if (Q.isEmptyOrNull(contains)) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.text, '')).toUpperCase().indexOf(contains) !== -1) {
				return true;
			}
			return false;
		},
		getItems: function() {
			var list = [];
			var roles = Q.getLookup('Administration.Role').get_items();
			for (var $t1 = 0; $t1 < roles.length; $t1++) {
				var role = roles[$t1];
				list.push({ id: role.RoleId.toString(), text: role.RoleName });
			}
			return list;
		}
	}, ss.makeGenericType(Serenity.CheckTreeEditor$1, [Object]), [Serenity.IDataGrid, Serenity.IGetEditValue, Serenity.ISetEditValue]);
	ss.initClass($AccController_Administration_RoleDialog, $asm, {
		getToolbarButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityDialog$2, [Object, Object]).prototype.getToolbarButtons.call(this);
			buttons.push({ title: Q.text('Site.RolePermissionDialog.EditButton'), cssClass: 'lock-button', onClick: ss.mkdel(this, function() {
				(new $AccController_Administration_RolePermissionDialog({ roleID: ss.unbox(this.get_entity().RoleId), title: this.get_entity().RoleName })).dialogOpen();
			}) });
			return buttons;
		},
		updateInterface: function() {
			ss.makeGenericType(Serenity.EntityDialog$2, [Object, Object]).prototype.updateInterface.call(this);
			this.toolbar.findButton('lock-button').toggleClass('disabled', this.get_isNewOrDeleted());
		}
	}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog, Serenity.IAsyncInit]);
	ss.initClass($AccController_Administration_RoleForm, $asm, {
		get_roleName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'RoleName');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Administration_RoleGrid, $asm, {
		getDefaultSortBy: function() {
			var $t1 = [];
			$t1.push('RoleName');
			return $t1;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid, Serenity.IAsyncInit]);
	ss.initClass($AccController_Administration_RolePermissionDialog, $asm, {
		getDialogOptions: function() {
			var opt = ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).prototype.getDialogOptions.call(this);
			var $t1 = [];
			$t1.push({ text: Q.text('Dialogs.OkButton'), click: ss.mkdel(this, function() {
				Q.serviceRequest('Administration/RolePermission/Update', { RoleID: this.options.roleID, Permissions: this.$permissions.get_value(), Module: null, Submodule: null }, ss.mkdel(this, function(response) {
					this.dialogClose();
					window.setTimeout(function() {
						Q.notifySuccess(Q.text('Site.RolePermissionDialog.SaveSuccess'));
					}, 0);
				}), null);
			}) });
			$t1.push({ text: Q.text('Dialogs.CancelButton'), click: ss.mkdel(this, this.dialogClose) });
			opt.buttons = $t1;
			opt.title = ss.formatString(Q.text('Site.RolePermissionDialog.DialogTitle'), this.options.title);
			return opt;
		},
		getTemplate: function() {
			return "<div id='~_Permissions'></div>";
		}
	}, ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]), [Serenity.IDialog]);
	ss.initClass($AccController_Administration_TranslationGrid, $asm, {
		onClick: function(e, row, cell) {
			ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.onClick.call(this, e, row, cell);
			if (e.isDefaultPrevented()) {
				return;
			}
			if ($(e.target).hasClass('source-text')) {
				e.preventDefault();
				var item = this.view.rows[row];
				var done = ss.mkdel(this, function() {
					item.CustomText = item.SourceText;
					this.view.updateItem(item.Key, item);
					this.$hasChanges = true;
				});
				if (Q.isTrimmedEmpty(item.CustomText) || ss.referenceEquals(Q.trimToEmpty(item.CustomText), Q.trimToEmpty(item.SourceText))) {
					done();
					return;
				}
				Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
			}
			if ($(e.target).hasClass('target-text')) {
				e.preventDefault();
				var item1 = this.view.rows[row];
				var done1 = ss.mkdel(this, function() {
					item1.CustomText = item1.TargetText;
					this.view.updateItem(item1.Key, item1);
					this.$hasChanges = true;
				});
				if (Q.isTrimmedEmpty(item1.CustomText) || ss.referenceEquals(Q.trimToEmpty(item1.CustomText), Q.trimToEmpty(item1.TargetText))) {
					done1();
					return;
				}
				Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done1);
			}
		},
		getColumnsAsync: function() {
			var columns = [];
			columns.push({ field: 'Key', width: 300, sortable: false });
			columns.push({
				field: 'SourceText',
				width: 300,
				sortable: false,
				format: function(ctx) {
					return Q.outerHtml($('<a/>').addClass('source-text').text(ss.coalesce(ss.cast(ctx.value, String), '')));
				}
			});
			columns.push({
				field: 'CustomText',
				width: 300,
				sortable: false,
				format: function(ctx1) {
					return Q.outerHtml($('<input/>').addClass('custom-text').attr('value', ss.cast(ctx1.value, String)).attr('type', 'text').attr('data-key', ss.cast(ctx1.item.Key, String)));
				}
			});
			columns.push({
				field: 'TargetText',
				width: 300,
				sortable: false,
				format: function(ctx2) {
					return Q.outerHtml($('<a/>').addClass('target-text').text(ss.coalesce(ss.cast(ctx2.value, String), '')));
				}
			});
			return RSVP.resolve(columns);
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element()).attr('placeholder', '--- ' + Q.text('Db.Administration.Translation.SourceLanguage') + ' ---');
			});
			var $t1 = Serenity.LookupEditorOptions.$ctor();
			$t1.lookupKey = 'Administration.Language';
			this.$sourceLanguage = Serenity.Widget.create(Serenity.LookupEditor).call(null, $t2, $t1, null);
			Serenity.WX.changeSelect2(this.$sourceLanguage, ss.mkdel(this, function(e1) {
				if (this.$hasChanges) {
					this.saveChanges(this.$targetLanguageKey).then(ss.mkdel(this, this.refresh), null);
				}
				else {
					this.refresh();
				}
			}));
			var $t4 = ss.mkdel(this, function(e2) {
				e2.appendTo(this.toolbar.get_element()).attr('placeholder', '--- ' + Q.text('Db.Administration.Translation.TargetLanguage') + ' ---');
			});
			var $t3 = Serenity.LookupEditorOptions.$ctor();
			$t3.lookupKey = 'Administration.Language';
			this.$targetLanguage = Serenity.Widget.create(Serenity.LookupEditor).call(null, $t4, $t3, null);
			Serenity.WX.changeSelect2(this.$targetLanguage, ss.mkdel(this, function(e3) {
				if (this.$hasChanges) {
					this.saveChanges(this.$targetLanguageKey).then(ss.mkdel(this, this.refresh), null);
				}
				else {
					this.refresh();
				}
			}));
		},
		saveChanges: function(language) {
			var translations = {};
			var $t1 = this.view.getItems();
			for (var $t2 = 0; $t2 < $t1.length; $t2++) {
				var item = $t1[$t2];
				translations[item.Key] = item.CustomText;
			}
			return RSVP.resolve(Q.serviceRequest('Administration/Translation/Update', { TargetLanguageID: language, Translations: translations }, null, null)).then(ss.mkdel(this, function() {
				this.$hasChanges = false;
				Q.notifySuccess('User translations in "' + language + '" language are saved to "user.texts.' + language + '.json" ' + 'file under "~/script/site/texts/user/"');
			}), null);
		},
		onViewSubmit: function() {
			var request = this.view.params;
			request.SourceLanguageID = this.$sourceLanguage.get_value();
			this.$targetLanguageKey = ss.coalesce(this.$targetLanguage.get_value(), '');
			request.TargetLanguageID = this.$targetLanguageKey;
			this.$hasChanges = false;
			return ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.onViewSubmit.call(this);
		},
		getButtons: function() {
			var $t1 = [];
			$t1.push({ title: 'Save Changes', onClick: ss.mkdel(this, function(e) {
				this.saveChanges(this.$targetLanguageKey).then(ss.mkdel(this, this.refresh), null);
			}), cssClass: 'apply-changes-button' });
			return $t1;
		},
		createQuickSearchInput: function() {
			Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.get_element(), ss.mkdel(this, function(field, searchText) {
				this.$searchText = searchText;
				this.view.setItems(this.view.getItems(), true);
			}), null);
		},
		onViewFilter: function(item) {
			if (!ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.onViewFilter.call(this, item)) {
				return false;
			}
			if (Q.isEmptyOrNull(this.$searchText)) {
				return true;
			}
			var searching = Select2.util.stripDiacritics(this.$searchText).toLowerCase();
			if (Q.isEmptyOrNull(searching)) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.Key, '')).toLowerCase().indexOf(searching) >= 0) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.SourceText, '')).toLowerCase().indexOf(searching) >= 0) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.TargetText, '')).toLowerCase().indexOf(searching) >= 0) {
				return true;
			}
			if (Select2.util.stripDiacritics(ss.coalesce(item.CustomText, '')).toLowerCase().indexOf(searching) >= 0) {
				return true;
			}
			return false;
		},
		usePager: function() {
			return false;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid, Serenity.IAsyncInit]);
	ss.initClass($AccController_Administration_UserDialog, $asm, {
		getToolbarButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityDialog$2, [Object, Object]).prototype.getToolbarButtons.call(this);
			buttons.push({ title: Q.text('Site.UserDialog.EditRolesButton'), cssClass: 'users-button', onClick: ss.mkdel(this, function() {
				(new $AccController_Administration_UserRoleDialog({ userID: ss.unbox(this.get_entity().UserId), username: this.get_entity().Username })).dialogOpen();
			}) });
			buttons.push({ title: Q.text('Site.UserDialog.EditPermissionsButton'), cssClass: 'lock-button', onClick: ss.mkdel(this, function() {
				(new $AccController_Administration_UserPermissionDialog({ userID: ss.unbox(this.get_entity().UserId), username: this.get_entity().Username })).dialogOpen();
			}) });
			if ($AccController_Administration_UserDialog.$admin_lv === '1') {
				buttons.push({ title: 'Super Admin', cssClass: 'users-button', onClick: ss.mkdel(this, function() {
					Q.confirm('Cấp quyền Super Admin?', ss.mkdel(this, function() {
						var request = {};
						request.Entity = this.get_entity();
						Q.serviceRequest('Administration/User/updateuser', request, ss.mkdel(this, function(s) {
							this.reloadById();
							this.dialogClose();
							//Q.NotifyInfo("ok");
						}), null);
					}));
				}) });
			}
			return buttons;
		},
		updateInterface: function() {
			ss.makeGenericType(Serenity.EntityDialog$2, [Object, Object]).prototype.updateInterface.call(this);
			this.toolbar.findButton('users-button').toggleClass('disabled', this.get_isNewOrDeleted());
			this.toolbar.findButton('lock-button').toggleClass('disabled', this.get_isNewOrDeleted());
		}
	}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Administration_UserForm, $asm, {
		get_username: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Username');
		},
		get_displayName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'DisplayName');
		},
		get_email: function() {
			return this.byId(Serenity.EmailEditor).call(this, 'Email');
		},
		get_password: function() {
			return this.byId(Serenity.PasswordEditor).call(this, 'Password');
		},
		get_passwordConfirm: function() {
			return this.byId(Serenity.PasswordEditor).call(this, 'PasswordConfirm');
		},
		get_source: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Source');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Administration_UserGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Administration_UserGrid.$user_name = t.Username;
				$AccController_Administration_UserGrid.$admin_lv = ss.cast(obj.adminlv, String);
				//Q.Log("user_name:  " + user_name + "  admin_lv:" + admin_lv);
				if ($AccController_Administration_UserGrid.$i_refresh === 1) {
					$AccController_Administration_UserGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//req.EqualityFilter["by_admin"] = user_name;
			if ($AccController_Administration_UserGrid.$admin_lv === '1') {
				req.EqualityFilter['by_admin'] = '';
			}
			else {
				req.EqualityFilter['by_admin'] = $AccController_Administration_UserGrid.$user_name;
			}
			req.EqualityFilter['by_admin'] = '';
			return true;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			//buttons.Add(new ToolButton
			//{
			//    Hint = "this is hint",
			//    Title = "new btn",
			//    CssClass = "button",
			//    OnClick = delegate
			//    {
			//        List<UserRow> lst =  this.View.GetItems();
			//        foreach(var item in lst)
			//        {
			//            if (item.Username != "tanhn")
			//            {
			//                item.DisplayName = "WWWWWWWWWW";
			//                this.View.UpdateItem(item.UserId,item);
			//            }
			//        }
			//    }
			//});
			return buttons;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			//columns.Insert(0, GridRowSelectionMixin.CreateSelectColumn(() => rowSelection));
			//columns.Add(new SlickColumn { Field = "UserId", Width = 55, CssClass = "align-right", Title = Q.Text("Db.Shared.RecordId") });
			columns.push({ field: 'Username', width: 150, format: this.itemLink(null, null, null, null, true) });
			columns.push({ field: 'DisplayName', width: 150 });
			columns.push({ field: 'Email', width: 250 });
			columns.push({ field: 'Source', width: 100 });
			columns.push({ field: 'by_admin', width: 100 });
			return columns;
		},
		getDefaultSortBy: function() {
			var $t1 = [];
			$t1.push('Username');
			return $t1;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Administration_UserPermissionDialog, $asm, {
		getDialogOptions: function() {
			var opt = ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).prototype.getDialogOptions.call(this);
			var $t1 = [];
			$t1.push({ text: Q.text('Dialogs.OkButton'), click: ss.mkdel(this, function() {
				Q.serviceRequest('Administration/UserPermission/Update', { UserID: this.options.userID, Permissions: this.$permissions.get_value(), Module: null, Submodule: null }, ss.mkdel(this, function(response) {
					this.dialogClose();
					window.setTimeout(function() {
						Q.notifySuccess(Q.text('Site.UserPermissionDialog.SaveSuccess'));
					}, 0);
				}), null);
			}) });
			$t1.push({ text: Q.text('Dialogs.CancelButton'), click: ss.mkdel(this, this.dialogClose) });
			opt.buttons = $t1;
			opt.title = ss.formatString(Q.text('Site.UserPermissionDialog.DialogTitle'), this.options.username);
			return opt;
		},
		getTemplate: function() {
			return "<div id='~_Permissions'></div>";
		}
	}, ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]), [Serenity.IDialog]);
	ss.initClass($AccController_Administration_UserRoleDialog, $asm, {
		getDialogOptions: function() {
			var opt = ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]).prototype.getDialogOptions.call(this);
			var $t1 = [];
			$t1.push({ text: Q.text('Dialogs.OkButton'), click: ss.mkdel(this, function() {
				Q.serviceRequest('Administration/UserRole/Update', { UserID: this.options.userID, Roles: Enumerable.from(this.$permissions.get_value()).select(function(x) {
					return parseInt(x, 10);
				}).toArray() }, ss.mkdel(this, function(response) {
					this.dialogClose();
					window.setTimeout(function() {
						Q.notifySuccess(Q.text('Site.UserRoleDialog.SaveSuccess'));
					}, 0);
				}), null);
			}) });
			$t1.push({ text: Q.text('Dialogs.CancelButton'), click: ss.mkdel(this, this.dialogClose) });
			opt.buttons = $t1;
			opt.title = ss.formatString(Q.text('Site.UserRoleDialog.DialogTitle'), this.options.username);
			return opt;
		},
		getTemplate: function() {
			return "<div id='~_Roles'></div>";
		}
	}, ss.makeGenericType(Serenity.TemplatedDialog$1, [Object]), [Serenity.IDialog]);
	ss.initClass($AccController_Ais_AisAddOUDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisAddOUForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_newOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewOu');
		},
		get_newJobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewJobtitle');
		},
		get_newRole: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewRole');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisAddOUGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Ais_AisAddOUGrid.$user_name = t.Username;
				$AccController_Ais_AisAddOUGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Ais_AisAddOUGrid.$i_refresh === 1) {
					$AccController_Ais_AisAddOUGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Ais_AisAddOUGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Ais_AisAddOUGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Ais/AisAddOU/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Ais_AisAddOUGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Ais/AisAddOU/updategroup', request1, function(s) {
							//Q.NotifyInfo("ok");
						}, null);
					}
					this.refresh();
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Ais/AisFile/CreateAddUserOURequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisFileDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisFileForm, $asm, {
		get_fileName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'FileName');
		},
		get_fileSize: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'FileSize');
		},
		get_contentType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ContentType');
		},
		get_filePath: function() {
			return this.byId(Serenity.StringEditor).call(this, 'FilePath');
		},
		get_uploaded: function() {
			return this.byId(Serenity.DateEditor).call(this, 'Uploaded');
		},
		get_uploadedBy: function() {
			return this.byId(Serenity.StringEditor).call(this, 'UploadedBy');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisFileGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisFileResultsDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisFileResultsForm, $asm, {
		get_fileId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'FileId');
		},
		get_reqId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'ReqId');
		},
		get_reqType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ReqType');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisFileResultsGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisLogDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisLogForm, $asm, {
		get_logType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LogType');
		},
		get_itemId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'ItemId');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisLogGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisUserChangeInfoDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisUserChangeInfoForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_jobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Jobtitle');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisUserChangeInfoGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Ais_AisUserChangeInfoGrid.$user_name = t.Username;
				$AccController_Ais_AisUserChangeInfoGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Ais_AisUserChangeInfoGrid.$i_refresh === 1) {
					$AccController_Ais_AisUserChangeInfoGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Ais_AisUserChangeInfoGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Ais_AisUserChangeInfoGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Ais/AisUserChangeInfo/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Ais_AisUserChangeInfoGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Ais/AisUserChangeInfo/updateuserchangeinfo', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Ais/AisFile/CreateUserChangeInfoRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					//Q.Alert(data.ToJson());
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisUserChangeOUDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisUserChangeOUForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_oldOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'OldOu');
		},
		get_newOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewOu');
		},
		get_newJobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewJobtitle');
		},
		get_newRole: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewRole');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisUserChangeOUGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Ais_AisUserChangeOUGrid.$user_name = t.Username;
				$AccController_Ais_AisUserChangeOUGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Ais_AisUserChangeOUGrid.$i_refresh === 1) {
					$AccController_Ais_AisUserChangeOUGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Ais_AisUserChangeOUGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Ais_AisUserChangeOUGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Ais/AisUserChangeOU/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Ais_AisUserChangeOUGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Ais/AisUserChangeOU/updateuserchangeOU', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Ais/AisFile/CreateUserChangeOURequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_AisUserDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_AisUserForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_ou: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Ou');
		},
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_jobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Jobtitle');
		},
		get_role: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Role');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_AisUserGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Ais_AisUserGrid.$user_name = t.Username;
				$AccController_Ais_AisUserGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Ais_AisUserGrid.$i_refresh === 1) {
					$AccController_Ais_AisUserGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Ais_AisUserGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Ais_AisUserGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Ais/AisUser/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Ais_AisUserGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Ais/AisUser/updateuser', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Ais/AisFile/CreateUserRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_GroupDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_GroupForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_parent: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Parent');
		},
		get_category: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Category');
		},
		get_shortname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Shortname');
		},
		get_relate: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Relate');
		},
		get_priority: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.TextAreaEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_GroupGrid, $asm, {
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Ais_GroupGrid.$user_name = t.Username;
				$AccController_Ais_GroupGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Ais_GroupGrid.$i_refresh === 1) {
					$AccController_Ais_GroupGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Ais_GroupGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Ais_GroupGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Ais/Group/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Ais_GroupGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Ais/Group/updategroup', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Ais/AisFile/CreateGroupRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Ais_TesttDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Ais_TesttForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Ais_TesttGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Common_LanguageSelection, $asm, {
		getLookupAsync: function() {
			return ss.makeGenericType(Serenity.LookupEditorBase$2, [Object, Object]).prototype.getLookupAsync.call(this).then(ss.mkdel(this, function(x) {
				if (!Enumerable.from(x.get_items()).any(ss.mkdel(this, function(z) {
					return ss.referenceEquals(z.LanguageId, this.$currentLanguage);
				}))) {
					var idx = this.$currentLanguage.lastIndexOf('-');
					if (idx >= 0) {
						this.$currentLanguage = this.$currentLanguage.substr(0, idx);
						if (!Enumerable.from(x.get_items()).any(ss.mkdel(this, function(z1) {
							return ss.referenceEquals(z1.LanguageId, this.$currentLanguage);
						}))) {
							this.$currentLanguage = 'en';
						}
					}
					else {
						this.$currentLanguage = 'en';
					}
				}
				return x;
			}), null);
		},
		updateItemsAsync: function() {
			return ss.makeGenericType(Serenity.LookupEditorBase$2, [Object, Object]).prototype.updateItemsAsync.call(this).then(ss.mkdel(this, function() {
				this.set_value(this.$currentLanguage);
			}), null);
		},
		getLookupKey: function() {
			return 'Administration.Language';
		},
		emptyItemText: function() {
			return null;
		}
	}, ss.makeGenericType(Serenity.LookupEditorBase$1, [Object]), [Serenity.IStringValue, Serenity.IAsyncInit]);
	ss.initClass($AccController_Common_SidebarSearch, $asm, {
		$updateMatchFlags: function(text) {
			var liList = this.$menuUL.find('li').removeClass('non-match');
			text = Q.trimToNull(text);
			if (ss.isNullOrUndefined(text)) {
				liList.removeClass('active');
				liList.show();
				liList.children('ul').addClass('collapse');
				return;
			}
			var parts = ss.netSplit(text, [44, 32].map(function(i) {
				return String.fromCharCode(i);
			}), null, 1);
			for (var i = 0; i < parts.length; i++) {
				parts[i] = Q.trimToNull(Select2.util.stripDiacritics(parts[i]).toUpperCase());
			}
			var items = liList;
			items.each(function(i1, e) {
				var x = $(e);
				var title = Select2.util.stripDiacritics(ss.coalesce(x.text(), '').toUpperCase());
				for (var $t1 = 0; $t1 < parts.length; $t1++) {
					var p = parts[$t1];
					if (ss.isValue(p) && !(title.indexOf(p) !== -1)) {
						x.addClass('non-match');
						break;
					}
				}
			});
			var matchingItems = items.not('.non-match');
			var visibles = matchingItems.parents('li').add(matchingItems);
			var nonVisibles = liList.not(visibles);
			nonVisibles.hide().addClass('non-match');
			visibles.show();
			liList.children('ul').removeClass('collapse');
		}
	}, Serenity.Widget);
	ss.initClass($AccController_Email_EmailChangeDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailChangeForm, $asm, {
		get_oldName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'OldName');
		},
		get_newName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewName');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailChangeGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Email_EmailChangeGrid.$user_name = t.Username;
				$AccController_Email_EmailChangeGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Email_EmailChangeGrid.$i_refresh === 1) {
					$AccController_Email_EmailChangeGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Email_EmailChangeGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Email_EmailChangeGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Email/EmailChange/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Email_EmailChangeGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Email/EmailChange/updateSubmit', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Email/EmailFile/CreateEmailChangeRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailFileDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailFileForm, $asm, {
		get_fileName: function() {
			return this.byId(Serenity.StringEditor).call(this, 'FileName');
		},
		get_fileSize: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'FileSize');
		},
		get_contentType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ContentType');
		},
		get_filePath: function() {
			return this.byId(Serenity.StringEditor).call(this, 'FilePath');
		},
		get_uploaded: function() {
			return this.byId(Serenity.DateEditor).call(this, 'Uploaded');
		},
		get_uploadedBy: function() {
			return this.byId(Serenity.StringEditor).call(this, 'UploadedBy');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailFileGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailGroupAccountDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailGroupAccountForm, $asm, {
		get_groupId: function() {
			return this.byId(Serenity.LookupEditor).call(this, 'GroupId');
		},
		get_account: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Account');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailGroupAccountGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Email_EmailGroupAccountGrid.$user_name = t.Username;
				$AccController_Email_EmailGroupAccountGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Email_EmailGroupAccountGrid.$i_refresh === 1) {
					$AccController_Email_EmailGroupAccountGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Email_EmailGroupAccountGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Email_EmailGroupAccountGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Email/EmailGroupAccount/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Email_EmailGroupAccountGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Email/EmailGroupAccount/updateSubmit', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailGroupDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailGroupForm, $asm, {
		get_alias: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Alias');
		},
		get_displayname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Displayname');
		},
		get_ou: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Ou');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailGroupGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Email_EmailGroupGrid.$user_name = t.Username;
				$AccController_Email_EmailGroupGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Email_EmailGroupGrid.$i_refresh === 1) {
					$AccController_Email_EmailGroupGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Email_EmailGroupGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Email_EmailGroupGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Email/EmailGroup/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Email_EmailGroupGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Email/EmailGroup/updateSubmit', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailLogDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailLogForm, $asm, {
		get_logType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LogType');
		},
		get_itemId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'ItemId');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailLogGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailNewDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailNewForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_alias: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Alias');
		},
		get_displayname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Displayname');
		},
		get_firstname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Firstname');
		},
		get_lastname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Lastname');
		},
		get_jobTitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'JobTitle');
		},
		get_department: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Department');
		},
		get_company: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Company');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_birthday: function() {
			return this.byId(Serenity.DateEditor).call(this, 'Birthday');
		},
		get_ou: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Ou');
		},
		get_userPrincipal: function() {
			return this.byId(Serenity.StringEditor).call(this, 'UserPrincipal');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailNewGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Email_EmailNewGrid.$user_name = t.Username;
				$AccController_Email_EmailNewGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Email_EmailNewGrid.$i_refresh === 1) {
					$AccController_Email_EmailNewGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Email_EmailNewGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Email_EmailNewGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Email/EmailNew/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Email_EmailNewGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Email/EmailNew/updateSubmit', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Email/EmailFile/CreateNewRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_EmailUpdateInfoDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_EmailUpdateInfoForm, $asm, {
		get_account: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Account');
		},
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_jobTitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'JobTitle');
		},
		get_department: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Department');
		},
		get_company: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Company');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_birthday: function() {
			return this.byId(Serenity.DateEditor).call(this, 'Birthday');
		},
		get_ou: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Ou');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_EmailUpdateInfoGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Email_EmailUpdateInfoGrid.$user_name = t.Username;
				$AccController_Email_EmailUpdateInfoGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Email_EmailUpdateInfoGrid.$i_refresh === 1) {
					$AccController_Email_EmailUpdateInfoGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			if ($AccController_Email_EmailUpdateInfoGrid.$admin_lv === '1') {
				req.EqualityFilter['By_User'] = '';
			}
			else {
				req.EqualityFilter['By_User'] = $AccController_Email_EmailUpdateInfoGrid.$user_name;
			}
			req.EqualityFilter['Submit'] = '0';
			return true;
		},
		getColumns: function() {
			var columns = ss.makeGenericType(Serenity.DataGrid$2, [Object, Object]).prototype.getColumns.call(this);
			ss.insert(columns, 0, Serenity.GridRowSelectionMixin.createSelectColumn(ss.mkdel(this, function() {
				return this.$rowSelection;
			})));
			return columns;
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			// var self = this;
			buttons.push({ title: 'Delete', cssClass: 'delete-button', onClick: ss.mkdel(this, function() {
				var selectedIDs = this.$rowSelection.getSelectedKeys();
				if (selectedIDs.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn xóa');
				}
				else {
					Q.confirm('Bạn có muốn xóa những bản ghi đã chọn?', ss.mkdel(this, function() {
						for (var $t1 = 0; $t1 < selectedIDs.length; $t1++) {
							var item = selectedIDs[$t1];
							//long id = (long)Convert.FromBase64String(item).ConvertToId();
							var id = parseInt(item);
							var request = {};
							request.EntityId = id;
							Q.serviceCall({ url: Q.resolveUrl('~/Services/Email/EmailUpdateInfo/Delete'), request: request, onSuccess: ss.mkdel(this, function(response) {
								this.$rowSelection = new Serenity.GridRowSelectionMixin(this);
								this.refresh();
							}) });
						}
					}));
				}
			}) });
			buttons.push({ title: 'Submit', cssClass: 'submit-button', onClick: ss.mkdel(this, function() {
				var selectedIDs1 = this.$rowSelection.getSelectedKeys();
				if ($AccController_Email_EmailUpdateInfoGrid.$admin_lv !== '1') {
					Q.notifyError('Không có quyền thực hiện chức năng này!');
				}
				else if (selectedIDs1.length === 0) {
					Q.notifyError('Phải chọn bản ghi muốn duyệt');
				}
				else {
					var selectedID = this.$rowSelection.getSelectedKeys();
					for (var $t2 = 0; $t2 < selectedID.length; $t2++) {
						var item1 = selectedID[$t2];
						var request1 = {};
						request1.Entity = this.get_view().getItemById(item1);
						Q.serviceRequest('Email/EmailUpdateInfo/updateSubmit', request1, ss.mkdel(this, function(s) {
							this.refresh();
						}), null);
					}
				}
			}) });
			return buttons;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$uploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$uploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Email/EmailFile/CreateUpdateInfoRequest');
				});
				$('input:file', this.$uploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Email_FileResultDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Email_FileResultForm, $asm, {
		get_fileId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'FileId');
		},
		get_reqId: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'ReqId');
		},
		get_reqType: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ReqType');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Email_FileResultGrid, $asm, {}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Membership_LoginForm, $asm, {
		get_username: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Username');
		},
		get_password: function() {
			return this.byId(Serenity.PasswordEditor).call(this, 'Password');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Membership_LoginPanel, $asm, {}, ss.makeGenericType(Serenity.PropertyDialog$1, [Object]), [Serenity.IDialog]);
	ss.initClass($AccController_Membership_RegisterForm, $asm, {
		get_username: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Username');
		},
		get_password: function() {
			return this.byId(Serenity.PasswordEditor).call(this, 'Password');
		},
		get_email: function() {
			return this.byId(Serenity.EmailEditor).call(this, 'Email');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Membership_RegisterPanel, $asm, {}, ss.makeGenericType(Serenity.PropertyDialog$1, [Object]), [Serenity.IDialog]);
	ss.initClass($AccController_Request_Ais_AisAddOUDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Request_Ais_AisAddOUForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_newOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewOu');
		},
		get_newJobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewJobtitle');
		},
		get_newRole: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewRole');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		},
		get_byUser: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ByUser');
		},
		get_submit: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Submit');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Request_Ais_AisAddOUGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Request_Ais_AisAddOUGrid.$user_name = t.Username;
				$AccController_Request_Ais_AisAddOUGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Request_Ais_AisAddOUGrid.$i_refresh === 1) {
					$AccController_Request_Ais_AisAddOUGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//if (admin_lv == "1")
			//    req.EqualityFilter["By_User"] = "";
			//else
			//    req.EqualityFilter["By_User"] = user_name;
			req.EqualityFilter['Submit'] = '1';
			return true;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$resultUploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$resultUploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Request_Ais/AisAddOU/GetResultFromFile');
				});
				$('input:file', this.$resultUploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			ss.removeAt(buttons, 0);
			ss.removeAt(buttons, 0);
			buttons.push({
				title: 'Download',
				cssClass: 'export-xlsx-button',
				onClick: function() {
					window.open(Q.resolveUrl('~/Request_Ais/AisAddOU/GetRequestFile?status=1'), '_blank');
				}
			});
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Request_Ais_AisUserChangeInfoDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Request_Ais_AisUserChangeInfoForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_jobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Jobtitle');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		},
		get_byUser: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ByUser');
		},
		get_submit: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Submit');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Request_Ais_AisUserChangeInfoGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Request_Ais_AisUserChangeInfoGrid.$user_name = t.Username;
				$AccController_Request_Ais_AisUserChangeInfoGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Request_Ais_AisUserChangeInfoGrid.$i_refresh === 1) {
					$AccController_Request_Ais_AisUserChangeInfoGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//if (admin_lv == "1")
			//    req.EqualityFilter["By_User"] = "";
			//else
			//    req.EqualityFilter["By_User"] = user_name;
			req.EqualityFilter['Submit'] = '1';
			return true;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$resultUploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$resultUploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Request_Ais/AisUserChangeInfo/GetResultFromFile');
				});
				$('input:file', this.$resultUploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			ss.removeAt(buttons, 0);
			ss.removeAt(buttons, 0);
			buttons.push({
				title: 'Download',
				cssClass: 'export-xlsx-button',
				onClick: function() {
					window.open(Q.resolveUrl('~/Request_Ais/AisUserChangeInfo/GetRequestFile?status=1'), '_blank');
				}
			});
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Request_Ais_AisUserChangeOUDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Request_Ais_AisUserChangeOUForm, $asm, {
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_oldOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'OldOu');
		},
		get_newOu: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewOu');
		},
		get_newJobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewJobtitle');
		},
		get_newRole: function() {
			return this.byId(Serenity.StringEditor).call(this, 'NewRole');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		},
		get_byUser: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ByUser');
		},
		get_submit: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Submit');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Request_Ais_AisUserChangeOUGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Request_Ais_AisUserChangeOUGrid.$user_name = t.Username;
				$AccController_Request_Ais_AisUserChangeOUGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Request_Ais_AisUserChangeOUGrid.$i_refresh === 1) {
					$AccController_Request_Ais_AisUserChangeOUGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//if (admin_lv == "1")
			//    req.EqualityFilter["By_User"] = "";
			//else
			//    req.EqualityFilter["By_User"] = user_name;
			req.EqualityFilter['Submit'] = '1';
			return true;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$resultUploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$resultUploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Request_Ais/AisUserChangeOU/GetResultFromFile');
				});
				$('input:file', this.$resultUploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			ss.removeAt(buttons, 0);
			ss.removeAt(buttons, 0);
			buttons.push({
				title: 'Download',
				cssClass: 'export-xlsx-button',
				onClick: function() {
					window.open(Q.resolveUrl('~/Request_Ais/AisUserChangeOU/GetRequestFile?status=1'), '_blank');
				}
			});
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Request_Ais_AisUserDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Request_Ais_AisUserForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_ou: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Ou');
		},
		get_email: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Email');
		},
		get_phone: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Phone');
		},
		get_mobile: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Mobile');
		},
		get_jobtitle: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Jobtitle');
		},
		get_role: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Role');
		},
		get_priority: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		},
		get_byUser: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ByUser');
		},
		get_submit: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Submit');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Request_Ais_AisUserGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Request_Ais_AisUserGrid.$user_name = t.Username;
				$AccController_Request_Ais_AisUserGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Request_Ais_AisUserGrid.$i_refresh === 1) {
					$AccController_Request_Ais_AisUserGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//if (admin_lv == "1")
			//    req.EqualityFilter["By_User"] = "";
			//else
			//    req.EqualityFilter["By_User"] = user_name;
			req.EqualityFilter['Submit'] = '1';
			return true;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$resultUploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$resultUploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Request_Ais/AisUser/GetResultFromFile');
				});
				$('input:file', this.$resultUploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			ss.removeAt(buttons, 0);
			ss.removeAt(buttons, 0);
			buttons.push({
				title: 'Download',
				cssClass: 'export-xlsx-button',
				onClick: function() {
					window.open(Q.resolveUrl('~/Request_Ais/AisUser/GetRequestFile?status=1'), '_blank');
				}
			});
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.initClass($AccController_Request_Ais_GroupDialog, $asm, {}, ss.makeGenericType(Serenity.EntityDialog$1, [Object]), [Serenity.IDialog, Serenity.IEditDialog]);
	ss.initClass($AccController_Request_Ais_GroupForm, $asm, {
		get_name: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Name');
		},
		get_parent: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Parent');
		},
		get_category: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Category');
		},
		get_shortname: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Shortname');
		},
		get_relate: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Relate');
		},
		get_priority: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Priority');
		},
		get_status: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Status');
		},
		get_result: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Result');
		},
		get_lastUpdated: function() {
			return this.byId(Serenity.DateEditor).call(this, 'LastUpdated');
		},
		get_lastUpdatedby: function() {
			return this.byId(Serenity.StringEditor).call(this, 'LastUpdatedby');
		},
		get_description: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Description');
		},
		get_idRequest: function() {
			return this.byId(Serenity.IntegerEditor).call(this, 'IdRequest');
		},
		get_byUser: function() {
			return this.byId(Serenity.StringEditor).call(this, 'ByUser');
		},
		get_submit: function() {
			return this.byId(Serenity.StringEditor).call(this, 'Submit');
		}
	}, Serenity.PrefixedContext);
	ss.initClass($AccController_Request_Ais_GroupGrid, $asm, {
		onViewSubmit: function() {
			var request = {};
			Q.serviceCall({ url: Q.resolveUrl('~/Administration/User/getUser'), request: request, onSuccess: ss.mkdel(this, function(response) {
				var obj = response;
				var t = obj;
				$AccController_Request_Ais_GroupGrid.$user_name = t.Username;
				$AccController_Request_Ais_GroupGrid.$admin_lv = ss.cast(obj.adminlv, String);
				if ($AccController_Request_Ais_GroupGrid.$i_refresh === 1) {
					$AccController_Request_Ais_GroupGrid.$i_refresh = 0;
					this.refresh();
				}
			}) });
			var req = this.view.params;
			req.EqualityFilter = req.EqualityFilter || {};
			//if (admin_lv == "1")
			//    req.EqualityFilter["By_User"] = "";
			//else
			//    req.EqualityFilter["By_User"] = user_name;
			req.EqualityFilter['Submit'] = '1';
			return true;
		},
		createToolbarExtensions: function() {
			ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.createToolbarExtensions.call(this);
			var $t2 = ss.mkdel(this, function(e) {
				e.appendTo(this.toolbar.get_element());
			});
			var $t1 = Serenity.ImageUploadEditorOptions.$ctor();
			$t1.allowNonImage = true;
			$t1.maxSize = 2048;
			this.$resultUploader = Serenity.Widget.create(Serenity.ImageUploadEditor).call(null, $t2, $t1, ss.mkdel(this, function(e1) {
				$('ul', e1.get_element()).hide();
				$('.delete-button', e1.get_element()).hide();
				$('input:file', this.$resultUploader.get_element()).bind('fileuploadadd', function(ev, data) {
					data.url = Q.resolveUrl('~/Request_Ais/Group/GetResultFromFile');
				});
				$('input:file', this.$resultUploader.get_element()).bind('fileuploaddone', ss.mkdel(this, function(ev1, data1) {
					if (!!ss.isValue(data1.Error)) {
						//Q.
						if (!!(data1.Error.Code === 'FileErr')) {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
						else {
							Q.notifyError(ss.cast(data1.Error.Message, String));
						}
					}
					else {
						this.refresh();
					}
				}));
			}));
		},
		getButtons: function() {
			var buttons = ss.makeGenericType(Serenity.EntityGrid$2, [Object, Object]).prototype.getButtons.call(this);
			ss.removeAt(buttons, 0);
			buttons.push({
				title: 'Download',
				cssClass: 'export-xlsx-button',
				onClick: function() {
					window.open(Q.resolveUrl('~/Request_Ais/Group/GetRequestFile?status=1'), '_blank');
				}
			});
			return buttons;
		}
	}, ss.makeGenericType(Serenity.EntityGrid$1, [Object]), [Serenity.IDataGrid]);
	ss.setMetadata($AccController_Administration_LanguageDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LanguageName'), new Serenity.FormKeyAttribute('Administration.Language'), new Serenity.LocalTextPrefixAttribute('Administration.Language'), new Serenity.ServiceAttribute('Administration/Language')] });
	ss.setMetadata($AccController_Administration_LanguageGrid, { attr: [new Serenity.ColumnsKeyAttribute('Administration.Language'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LanguageName'), new Serenity.DialogTypeAttribute($AccController_Administration_LanguageDialog), new Serenity.LocalTextPrefixAttribute('Administration.Language'), new Serenity.ServiceAttribute('Administration/Language')] });
	ss.setMetadata($AccController_Administration_PermissionCheckEditor, { attr: [new Serenity.EditorAttribute()] });
	ss.setMetadata($AccController_Administration_PermissionModuleEditor, { attr: [new Serenity.EditorAttribute()] });
	ss.setMetadata($AccController_Administration_RoleCheckEditor, { attr: [new Serenity.EditorAttribute()] });
	ss.setMetadata($AccController_Administration_RoleDialog, { attr: [new Serenity.IdPropertyAttribute('RoleId'), new Serenity.NamePropertyAttribute('RoleName'), new Serenity.FormKeyAttribute('Administration.Role'), new Serenity.LocalTextPrefixAttribute('Administration.Role'), new Serenity.ServiceAttribute('Administration/Role')] });
	ss.setMetadata($AccController_Administration_RoleGrid, { attr: [new Serenity.ColumnsKeyAttribute('Administration.Role'), new Serenity.IdPropertyAttribute('RoleId'), new Serenity.NamePropertyAttribute('RoleName'), new Serenity.DialogTypeAttribute($AccController_Administration_RoleDialog), new Serenity.LocalTextPrefixAttribute('Administration.Role'), new Serenity.ServiceAttribute('Administration/Role')] });
	ss.setMetadata($AccController_Administration_TranslationGrid, { attr: [new Serenity.ColumnsKeyAttribute('Administration.Translation'), new Serenity.IdPropertyAttribute('Key'), new Serenity.LocalTextPrefixAttribute('Administration.Translation'), new Serenity.ServiceAttribute('Administration/Translation')] });
	ss.setMetadata($AccController_Administration_UserDialog, { attr: [new Serenity.IdPropertyAttribute('UserId'), new Serenity.NamePropertyAttribute('Username'), new Serenity.IsActivePropertyAttribute('IsActive'), new Serenity.FormKeyAttribute('Administration.User'), new Serenity.LocalTextPrefixAttribute('Administration.User'), new Serenity.ServiceAttribute('Administration/User')] });
	ss.setMetadata($AccController_Administration_UserGrid, { attr: [new Serenity.IdPropertyAttribute('UserId'), new Serenity.NamePropertyAttribute('Username'), new Serenity.IsActivePropertyAttribute('IsActive'), new Serenity.DialogTypeAttribute($AccController_Administration_UserDialog), new Serenity.LocalTextPrefixAttribute('Administration.User'), new Serenity.ServiceAttribute('Administration/User')] });
	ss.setMetadata($AccController_Ais_AisAddOUDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Ais.AisAddOU'), new Serenity.LocalTextPrefixAttribute('Ais.AisAddOU'), new Serenity.ServiceAttribute('Ais/AisAddOU')] });
	ss.setMetadata($AccController_Ais_AisAddOUGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisAddOU'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Ais_AisAddOUDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisAddOU'), new Serenity.ServiceAttribute('Ais/AisAddOU')] });
	ss.setMetadata($AccController_Ais_AisFileDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('FileName'), new Serenity.FormKeyAttribute('Ais.AisFile'), new Serenity.LocalTextPrefixAttribute('Ais.AisFile'), new Serenity.ServiceAttribute('Ais/AisFile')] });
	ss.setMetadata($AccController_Ais_AisFileGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisFile'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('FileName'), new Serenity.DialogTypeAttribute($AccController_Ais_AisFileDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisFile'), new Serenity.ServiceAttribute('Ais/AisFile')] });
	ss.setMetadata($AccController_Ais_AisFileResultsDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.FormKeyAttribute('Ais.AisFileResults'), new Serenity.LocalTextPrefixAttribute('Ais.AisFileResults'), new Serenity.ServiceAttribute('Ais/AisFileResults')] });
	ss.setMetadata($AccController_Ais_AisFileResultsGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisFileResults'), new Serenity.IdPropertyAttribute('Id'), new Serenity.DialogTypeAttribute($AccController_Ais_AisFileResultsDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisFileResults'), new Serenity.ServiceAttribute('Ais/AisFileResults')] });
	ss.setMetadata($AccController_Ais_AisLogDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LastUpdatedby'), new Serenity.FormKeyAttribute('Ais.AisLog'), new Serenity.LocalTextPrefixAttribute('Ais.AisLog'), new Serenity.ServiceAttribute('Ais/AisLog')] });
	ss.setMetadata($AccController_Ais_AisLogGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisLog'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LastUpdatedby'), new Serenity.DialogTypeAttribute($AccController_Ais_AisLogDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisLog'), new Serenity.ServiceAttribute('Ais/AisLog')] });
	ss.setMetadata($AccController_Ais_AisUserChangeInfoDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Ais.AisUserChangeInfo'), new Serenity.LocalTextPrefixAttribute('Ais.AisUserChangeInfo'), new Serenity.ServiceAttribute('Ais/AisUserChangeInfo')] });
	ss.setMetadata($AccController_Ais_AisUserChangeInfoGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisUserChangeInfo'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Ais_AisUserChangeInfoDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisUserChangeInfo'), new Serenity.ServiceAttribute('Ais/AisUserChangeInfo')] });
	ss.setMetadata($AccController_Ais_AisUserChangeOUDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Ais.AisUserChangeOU'), new Serenity.LocalTextPrefixAttribute('Ais.AisUserChangeOU'), new Serenity.ServiceAttribute('Ais/AisUserChangeOU')] });
	ss.setMetadata($AccController_Ais_AisUserChangeOUGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisUserChangeOU'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Ais_AisUserChangeOUDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisUserChangeOU'), new Serenity.ServiceAttribute('Ais/AisUserChangeOU')] });
	ss.setMetadata($AccController_Ais_AisUserDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Ou'), new Serenity.FormKeyAttribute('Ais.AisUser'), new Serenity.LocalTextPrefixAttribute('Ais.AisUser'), new Serenity.ServiceAttribute('Ais/AisUser')] });
	ss.setMetadata($AccController_Ais_AisUserGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.AisUser'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Ou'), new Serenity.DialogTypeAttribute($AccController_Ais_AisUserDialog), new Serenity.LocalTextPrefixAttribute('Ais.AisUser'), new Serenity.ServiceAttribute('Ais/AisUser')] });
	ss.setMetadata($AccController_Ais_GroupDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.FormKeyAttribute('Ais.Group'), new Serenity.LocalTextPrefixAttribute('Ais.Group'), new Serenity.ServiceAttribute('Ais/Group')] });
	ss.setMetadata($AccController_Ais_GroupGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.Group'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.DialogTypeAttribute($AccController_Ais_GroupDialog), new Serenity.LocalTextPrefixAttribute('Ais.Group'), new Serenity.ServiceAttribute('Ais/Group')] });
	ss.setMetadata($AccController_Ais_TesttDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.FormKeyAttribute('Ais.Testt'), new Serenity.LocalTextPrefixAttribute('Ais.Testt'), new Serenity.ServiceAttribute('Ais/Testt')] });
	ss.setMetadata($AccController_Ais_TesttGrid, { attr: [new Serenity.ColumnsKeyAttribute('Ais.Testt'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.DialogTypeAttribute($AccController_Ais_TesttDialog), new Serenity.LocalTextPrefixAttribute('Ais.Testt'), new Serenity.ServiceAttribute('Ais/Testt')] });
	ss.setMetadata($AccController_Common_GridEditorBase$1, { attr: [new Serenity.ElementAttribute('<div/>'), new Serenity.EditorAttribute(), new Serenity.IdPropertyAttribute('__id')] });
	ss.setMetadata($AccController_Common_GridEditorDialog$1, { attr: [new Serenity.IdPropertyAttribute('__id')] });
	ss.setMetadata($AccController_Email_EmailChangeDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('OldName'), new Serenity.FormKeyAttribute('Email.EmailChange'), new Serenity.LocalTextPrefixAttribute('Email.EmailChange'), new Serenity.ServiceAttribute('Email/EmailChange')] });
	ss.setMetadata($AccController_Email_EmailChangeGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailChange'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('OldName'), new Serenity.DialogTypeAttribute($AccController_Email_EmailChangeDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailChange'), new Serenity.ServiceAttribute('Email/EmailChange')] });
	ss.setMetadata($AccController_Email_EmailFileDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('FileName'), new Serenity.FormKeyAttribute('Email.EmailFile'), new Serenity.LocalTextPrefixAttribute('Email.EmailFile'), new Serenity.ServiceAttribute('Email/EmailFile')] });
	ss.setMetadata($AccController_Email_EmailFileGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailFile'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('FileName'), new Serenity.DialogTypeAttribute($AccController_Email_EmailFileDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailFile'), new Serenity.ServiceAttribute('Email/EmailFile')] });
	ss.setMetadata($AccController_Email_EmailGroupAccountDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Account'), new Serenity.FormKeyAttribute('Email.EmailGroupAccount'), new Serenity.LocalTextPrefixAttribute('Email.EmailGroupAccount'), new Serenity.ServiceAttribute('Email/EmailGroupAccount')] });
	ss.setMetadata($AccController_Email_EmailGroupAccountGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailGroupAccount'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Account'), new Serenity.DialogTypeAttribute($AccController_Email_EmailGroupAccountDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailGroupAccount'), new Serenity.ServiceAttribute('Email/EmailGroupAccount')] });
	ss.setMetadata($AccController_Email_EmailGroupDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Alias'), new Serenity.FormKeyAttribute('Email.EmailGroup'), new Serenity.LocalTextPrefixAttribute('Email.EmailGroup'), new Serenity.ServiceAttribute('Email/EmailGroup')] });
	ss.setMetadata($AccController_Email_EmailGroupGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailGroup'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Alias'), new Serenity.DialogTypeAttribute($AccController_Email_EmailGroupDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailGroup'), new Serenity.ServiceAttribute('Email/EmailGroup')] });
	ss.setMetadata($AccController_Email_EmailLogDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LastUpdatedby'), new Serenity.FormKeyAttribute('Email.EmailLog'), new Serenity.LocalTextPrefixAttribute('Email.EmailLog'), new Serenity.ServiceAttribute('Email/EmailLog')] });
	ss.setMetadata($AccController_Email_EmailLogGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailLog'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('LastUpdatedby'), new Serenity.DialogTypeAttribute($AccController_Email_EmailLogDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailLog'), new Serenity.ServiceAttribute('Email/EmailLog')] });
	ss.setMetadata($AccController_Email_EmailNewDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.FormKeyAttribute('Email.EmailNew'), new Serenity.LocalTextPrefixAttribute('Email.EmailNew'), new Serenity.ServiceAttribute('Email/EmailNew')] });
	ss.setMetadata($AccController_Email_EmailNewGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailNew'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.DialogTypeAttribute($AccController_Email_EmailNewDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailNew'), new Serenity.ServiceAttribute('Email/EmailNew')] });
	ss.setMetadata($AccController_Email_EmailUpdateInfoDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Account'), new Serenity.FormKeyAttribute('Email.EmailUpdateInfo'), new Serenity.LocalTextPrefixAttribute('Email.EmailUpdateInfo'), new Serenity.ServiceAttribute('Email/EmailUpdateInfo')] });
	ss.setMetadata($AccController_Email_EmailUpdateInfoGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.EmailUpdateInfo'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Account'), new Serenity.DialogTypeAttribute($AccController_Email_EmailUpdateInfoDialog), new Serenity.LocalTextPrefixAttribute('Email.EmailUpdateInfo'), new Serenity.ServiceAttribute('Email/EmailUpdateInfo')] });
	ss.setMetadata($AccController_Email_FileResultDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.FormKeyAttribute('Email.FileResult'), new Serenity.LocalTextPrefixAttribute('Email.FileResult'), new Serenity.ServiceAttribute('Email/FileResult')] });
	ss.setMetadata($AccController_Email_FileResultGrid, { attr: [new Serenity.ColumnsKeyAttribute('Email.FileResult'), new Serenity.IdPropertyAttribute('Id'), new Serenity.DialogTypeAttribute($AccController_Email_FileResultDialog), new Serenity.LocalTextPrefixAttribute('Email.FileResult'), new Serenity.ServiceAttribute('Email/FileResult')] });
	ss.setMetadata($AccController_Membership_LoginPanel, { attr: [new Serenity.PanelAttribute(), new Serenity.FormKeyAttribute('Membership.Login')] });
	ss.setMetadata($AccController_Membership_RegisterPanel, { attr: [new Serenity.PanelAttribute(), new Serenity.FormKeyAttribute('Membership.Register')] });
	ss.setMetadata($AccController_Request_Ais_AisAddOUDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Request_Ais.AisAddOU'), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisAddOU'), new Serenity.ServiceAttribute('Request_Ais/AisAddOU')] });
	ss.setMetadata($AccController_Request_Ais_AisAddOUGrid, { attr: [new Serenity.ColumnsKeyAttribute('Request_Ais.AisAddOU'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Request_Ais_AisAddOUDialog), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisAddOU'), new Serenity.ServiceAttribute('Request_Ais/AisAddOU')] });
	ss.setMetadata($AccController_Request_Ais_AisUserChangeInfoDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Request_Ais.AisUserChangeInfo'), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUserChangeInfo'), new Serenity.ServiceAttribute('Request_Ais/AisUserChangeInfo')] });
	ss.setMetadata($AccController_Request_Ais_AisUserChangeInfoGrid, { attr: [new Serenity.ColumnsKeyAttribute('Request_Ais.AisUserChangeInfo'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Request_Ais_AisUserChangeInfoDialog), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUserChangeInfo'), new Serenity.ServiceAttribute('Request_Ais/AisUserChangeInfo')] });
	ss.setMetadata($AccController_Request_Ais_AisUserChangeOUDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.FormKeyAttribute('Request_Ais.AisUserChangeOU'), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUserChangeOU'), new Serenity.ServiceAttribute('Request_Ais/AisUserChangeOU')] });
	ss.setMetadata($AccController_Request_Ais_AisUserChangeOUGrid, { attr: [new Serenity.ColumnsKeyAttribute('Request_Ais.AisUserChangeOU'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Email'), new Serenity.DialogTypeAttribute($AccController_Request_Ais_AisUserChangeOUDialog), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUserChangeOU'), new Serenity.ServiceAttribute('Request_Ais/AisUserChangeOU')] });
	ss.setMetadata($AccController_Request_Ais_AisUserDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.FormKeyAttribute('Request_Ais.AisUser'), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUser'), new Serenity.ServiceAttribute('Request_Ais/AisUser')] });
	ss.setMetadata($AccController_Request_Ais_AisUserGrid, { attr: [new Serenity.ColumnsKeyAttribute('Request_Ais.AisUser'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.DialogTypeAttribute($AccController_Request_Ais_AisUserDialog), new Serenity.LocalTextPrefixAttribute('Request_Ais.AisUser'), new Serenity.ServiceAttribute('Request_Ais/AisUser')] });
	ss.setMetadata($AccController_Request_Ais_GroupDialog, { attr: [new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.FormKeyAttribute('Request_Ais.Group'), new Serenity.LocalTextPrefixAttribute('Request_Ais.Group'), new Serenity.ServiceAttribute('Request_Ais/Group')] });
	ss.setMetadata($AccController_Request_Ais_GroupGrid, { attr: [new Serenity.ColumnsKeyAttribute('Request_Ais.Group'), new Serenity.IdPropertyAttribute('Id'), new Serenity.NamePropertyAttribute('Name'), new Serenity.DialogTypeAttribute($AccController_Request_Ais_GroupDialog), new Serenity.LocalTextPrefixAttribute('Request_Ais.Group'), new Serenity.ServiceAttribute('Request_Ais/Group')] });
	(function() {
		Q$Config.rootNamespaces.push('AccController');
	})();
	(function() {
		$AccController_Administration_UserDialog.$user_name = '';
		$AccController_Administration_UserDialog.$i_refresh = 1;
		$AccController_Administration_UserDialog.$admin_lv = '1';
	})();
	(function() {
		$AccController_Administration_UserGrid.$user_name = '';
		$AccController_Administration_UserGrid.$i_refresh = 1;
		$AccController_Administration_UserGrid.$admin_lv = '1';
	})();
	(function() {
		$AccController_Ais_AisAddOUGrid.$user_name = '';
		$AccController_Ais_AisAddOUGrid.$i_refresh = 1;
		$AccController_Ais_AisAddOUGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Ais_AisUserChangeInfoGrid.$user_name = '';
		$AccController_Ais_AisUserChangeInfoGrid.$i_refresh = 1;
		$AccController_Ais_AisUserChangeInfoGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Ais_AisUserChangeOUGrid.$user_name = '';
		$AccController_Ais_AisUserChangeOUGrid.$i_refresh = 1;
		$AccController_Ais_AisUserChangeOUGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Ais_AisUserGrid.$user_name = '';
		$AccController_Ais_AisUserGrid.$i_refresh = 1;
		$AccController_Ais_AisUserGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Ais_GroupGrid.$user_name = '';
		$AccController_Ais_GroupGrid.$i_refresh = 1;
		$AccController_Ais_GroupGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Email_EmailChangeGrid.$user_name = '';
		$AccController_Email_EmailChangeGrid.$i_refresh = 1;
		$AccController_Email_EmailChangeGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Email_EmailGroupAccountGrid.$user_name = '';
		$AccController_Email_EmailGroupAccountGrid.$i_refresh = 1;
		$AccController_Email_EmailGroupAccountGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Email_EmailGroupGrid.$user_name = '';
		$AccController_Email_EmailGroupGrid.$i_refresh = 1;
		$AccController_Email_EmailGroupGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Email_EmailNewGrid.$user_name = '';
		$AccController_Email_EmailNewGrid.$i_refresh = 1;
		$AccController_Email_EmailNewGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Email_EmailUpdateInfoGrid.$user_name = '';
		$AccController_Email_EmailUpdateInfoGrid.$i_refresh = 1;
		$AccController_Email_EmailUpdateInfoGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Request_Ais_AisAddOUGrid.$user_name = '';
		$AccController_Request_Ais_AisAddOUGrid.$i_refresh = 1;
		$AccController_Request_Ais_AisAddOUGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Request_Ais_AisUserChangeInfoGrid.$user_name = '';
		$AccController_Request_Ais_AisUserChangeInfoGrid.$i_refresh = 1;
		$AccController_Request_Ais_AisUserChangeInfoGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Request_Ais_AisUserChangeOUGrid.$user_name = '';
		$AccController_Request_Ais_AisUserChangeOUGrid.$i_refresh = 1;
		$AccController_Request_Ais_AisUserChangeOUGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Request_Ais_AisUserGrid.$user_name = '';
		$AccController_Request_Ais_AisUserGrid.$i_refresh = 1;
		$AccController_Request_Ais_AisUserGrid.$admin_lv = '-1';
	})();
	(function() {
		$AccController_Request_Ais_GroupGrid.$user_name = '';
		$AccController_Request_Ais_GroupGrid.$i_refresh = 1;
		$AccController_Request_Ais_GroupGrid.$admin_lv = '-1';
	})();
})();
