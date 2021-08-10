<script type="text/javascript"> 
var script_xDmsUGroupUsers = {
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
    validate_GroupID: function(sender) {
      var Prefix = sender.id.replace('GroupID','');
      this.validated_FK_xDMS_GroupUsers_GroupID_main = true;
      this.validate_FK_xDMS_GroupUsers_GroupID(sender,Prefix);
      },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_xDMS_GroupUsers_UserID_main = true;
      this.validate_FK_xDMS_GroupUsers_UserID(sender,Prefix);
      },
    validate_FK_xDMS_GroupUsers_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_xDMS_GroupUsers_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_GroupUsers_UserID(value, this.validated_FK_xDMS_GroupUsers_UserID);
      },
    validated_FK_xDMS_GroupUsers_UserID_main: false,
    validated_FK_xDMS_GroupUsers_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsUGroupUsers.validated_FK_xDMS_GroupUsers_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_GroupUsers_GroupID: function(o,Prefix) {
      var value = o.id;
      var GroupID = $get(Prefix + 'GroupID');
      if(GroupID.value==''){
        if(this.validated_FK_xDMS_GroupUsers_GroupID_main){
          var o_d = $get(Prefix + 'GroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_GroupUsers_GroupID(value, this.validated_FK_xDMS_GroupUsers_GroupID);
      },
    validated_FK_xDMS_GroupUsers_GroupID_main: false,
    validated_FK_xDMS_GroupUsers_GroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsUGroupUsers.validated_FK_xDMS_GroupUsers_GroupID_main){
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
