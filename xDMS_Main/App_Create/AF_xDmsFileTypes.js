<script type="text/javascript"> 
var script_xDmsFileTypes = {
    ACEReleaseWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReleaseWorkflowID','');
      var F_ReleaseWorkflowID = $get(sender._element.id);
      var F_ReleaseWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReleaseWorkflowID.value = p[0];
      F_ReleaseWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEReleaseWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReleaseWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReleaseWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReviseWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReviseWorkflowID','');
      var F_ReviseWorkflowID = $get(sender._element.id);
      var F_ReviseWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReviseWorkflowID.value = p[0];
      F_ReviseWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEReviseWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReviseWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReviseWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ReleaseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReleaseWorkflowID','');
      this.validated_FK_xDMS_FileTypes_ReleaseWorkflowID_main = true;
      this.validate_FK_xDMS_FileTypes_ReleaseWorkflowID(sender,Prefix);
      },
    validate_ReviseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReviseWorkflowID','');
      this.validated_FK_xDMS_FileTypes_ReviseWorkflowID_main = true;
      this.validate_FK_xDMS_FileTypes_ReviseWorkflowID(sender,Prefix);
      },
    validate_FK_xDMS_FileTypes_ReleaseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReleaseWorkflowID = $get(Prefix + 'ReleaseWorkflowID');
      if(ReleaseWorkflowID.value==''){
        if(this.validated_FK_xDMS_FileTypes_ReleaseWorkflowID_main){
          var o_d = $get(Prefix + 'ReleaseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReleaseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FileTypes_ReleaseWorkflowID(value, this.validated_FK_xDMS_FileTypes_ReleaseWorkflowID);
      },
    validated_FK_xDMS_FileTypes_ReleaseWorkflowID_main: false,
    validated_FK_xDMS_FileTypes_ReleaseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFileTypes.validated_FK_xDMS_FileTypes_ReleaseWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FileTypes_ReviseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReviseWorkflowID = $get(Prefix + 'ReviseWorkflowID');
      if(ReviseWorkflowID.value==''){
        if(this.validated_FK_xDMS_FileTypes_ReviseWorkflowID_main){
          var o_d = $get(Prefix + 'ReviseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReviseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FileTypes_ReviseWorkflowID(value, this.validated_FK_xDMS_FileTypes_ReviseWorkflowID);
      },
    validated_FK_xDMS_FileTypes_ReviseWorkflowID_main: false,
    validated_FK_xDMS_FileTypes_ReviseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFileTypes.validated_FK_xDMS_FileTypes_ReviseWorkflowID_main){
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
