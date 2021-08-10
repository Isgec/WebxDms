<script type="text/javascript"> 
var script_xDmsWorkflows = {
    ACEParentWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ParentWorkflowID','');
      var F_ParentWorkflowID = $get(sender._element.id);
      var F_ParentWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ParentWorkflowID.value = p[0];
      F_ParentWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEParentWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ParentWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEParentWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEUserID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UserID','');
      var F_UserID = $get(sender._element.id);
      var F_UserID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UserID.value = p[0];
      F_UserID_Display.innerHTML = e.get_text();
    },
    ACEUserID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UserID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUserID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GroupID','');
      var F_GroupID = $get(sender._element.id);
      var F_GroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GroupID.value = p[0];
      F_GroupID_Display.innerHTML = e.get_text();
    },
    ACEGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ParentWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ParentWorkflowID','');
      this.validated_FK_xDMS_Workflows_ParentWorkflowID_main = true;
      this.validate_FK_xDMS_Workflows_ParentWorkflowID(sender,Prefix);
      },
    validate_InitialStatusID: function(sender) {
      var Prefix = sender.id.replace('InitialStatusID','');
      this.validated_FK_xDMS_Workflows_InitialStatusID_main = true;
      this.validate_FK_xDMS_Workflows_InitialStatusID(sender,Prefix);
      },
    validate_FinalStatusID: function(sender) {
      var Prefix = sender.id.replace('FinalStatusID','');
      this.validated_FK_xDMS_Workflows_FinalStatusID_main = true;
      this.validate_FK_xDMS_Workflows_FinalStatusID(sender,Prefix);
      },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_xDMS_Workflows_UserID_main = true;
      this.validate_FK_xDMS_Workflows_UserID(sender,Prefix);
      },
    validate_GroupID: function(sender) {
      var Prefix = sender.id.replace('GroupID','');
      this.validated_FK_xDMS_Workflows_GroupID_main = true;
      this.validate_FK_xDMS_Workflows_GroupID(sender,Prefix);
      },
    validate_FK_xDMS_Workflows_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_xDMS_Workflows_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Workflows_UserID(value, this.validated_FK_xDMS_Workflows_UserID);
      },
    validated_FK_xDMS_Workflows_UserID_main: false,
    validated_FK_xDMS_Workflows_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsWorkflows.validated_FK_xDMS_Workflows_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Workflows_GroupID: function(o,Prefix) {
      var value = o.id;
      var GroupID = $get(Prefix + 'GroupID');
      if(GroupID.value==''){
        if(this.validated_FK_xDMS_Workflows_GroupID_main){
          var o_d = $get(Prefix + 'GroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Workflows_GroupID(value, this.validated_FK_xDMS_Workflows_GroupID);
      },
    validated_FK_xDMS_Workflows_GroupID_main: false,
    validated_FK_xDMS_Workflows_GroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsWorkflows.validated_FK_xDMS_Workflows_GroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Workflows_ParentWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ParentWorkflowID = $get(Prefix + 'ParentWorkflowID');
      if(ParentWorkflowID.value==''){
        if(this.validated_FK_xDMS_Workflows_ParentWorkflowID_main){
          var o_d = $get(Prefix + 'ParentWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Workflows_ParentWorkflowID(value, this.validated_FK_xDMS_Workflows_ParentWorkflowID);
      },
    validated_FK_xDMS_Workflows_ParentWorkflowID_main: false,
    validated_FK_xDMS_Workflows_ParentWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsWorkflows.validated_FK_xDMS_Workflows_ParentWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
