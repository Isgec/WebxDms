<%@ Control Language="VB" AutoEventWireup="false" ClientIDMode="Static" CodeFile="lgMessageBox.ascx.vb" Inherits="lgMessageBox" %>
<script>
	var lgMessageBox = {
		MessageBoxTitle: 'Dynamic Data',
		CallBackMethodName: '',
		CallBackMethodArguments: '',
		CancellingScript: '',
		CancelledScript: '',
		CancelReturn: false,

		Execute: function(title, method, args) {
			$get('tdTitle').innerHTML = title;
			var dData = $get('dynamicData');
			dData.innerHTML = '';
			dData.style.display = 'block';
			var doc = $get('IfBd1');
			doc.style.display = 'none';
			var fdoc = doc.contentDocument || doc.contentWindow.document;
			fdoc.getElementsByTagName('body')[0].innerHTML = '';
			var toExecute = 'PageMethods.' + method + '(' + args + ',this.showMessageMPV,this.showErrorMPV)';
			eval(toExecute);
			return false;
		},
		ExecuteURL: function(title, url) {
			$get('tdTitle').innerHTML = title;
			var dData = $get('dynamicData');
			dData.style.display = 'none';
			dData.innerHTML = '';
			var doc = $get('IfBd1');
			var fdoc = doc.contentDocument || doc.contentWindow.document;
			fdoc.getElementsByTagName('body')[0].innerHTML = "<div><img alt='Loading' src='../../Images/xLoading.gif' style='height:240px;width:360px;' /></div>";
			doc.style.display = 'block';
			doc.src = url;
			this.initialSize();
			$find('mpe1Box').show();
			return false;
		},
		CancelMessage: function() {
			try {
				eval(this.CancellingScript);
			} catch (ex) { }
			this.hideMessageMPV();
			try {
				eval(this.CancelledScript);
			} catch (ex) { }
			return this.CancelReturn;
		},
		initialSize:function(){
			var ht = 200;
			var wt = 400;
			var pnl = $get('<%=pnl1.ClientID %>');
		  var o = $get('IfBd1');
			pnl.height = ht;
			pnl.width = wt;
			$get('mboxtable').width = wt;
			$get('tdTitle').width = wt;
			o.height = ht;
			o.width = wt;
		},
		hideMessageMPV: function() {
			var mPB = $find('mpe1Box');
			mPB.hide();
			this.initialSize();
			return false;
		},
		showMessageMPV: function(ev) {
			var mPB = $find('mpe1Box');
			var dData = $get('dynamicData');
			if (ev) {
				dData.innerHTML = ev;
			}
			mPB.show();
			return false;
		},
		close: function() {
			this.hideMessageMPV();
			return false;
		},
		showErrorMPV: function(ev) {
			var mPB = $find('mpe1Box');
			var dData = $get('dynamicData');
			if (ev) {
				dData.innerHTML = ev;
			}
			this.resizeFrame(dData);
			mPB.show();
			return false;
		},
		resizeFrame: function (x,y) {
		  var o = $get('IfBd1');
			var ht = 200;
			var wt = 400;
		  try{
			  var doc = document.frames[o.id];
			  if (doc) {
				  ht = doc.document.body.scrollHeight + 20;
				  wt = doc.document.body.scrollWidth + 30;
				  //alert(wt + ', ' + ht);
			  }
		  } catch (e) {
		    try{
		      //var doc = window.frames[o.id];
		      //if (doc) {
		      //  ht = doc.document.body.scrollHeight + 20;
		      //  wt = doc.document.body.scrollWidth + 30;
		      //}
		      wt = x + 30;
		      ht = y + 20;
        } catch (x) {
		      wt = x + 30;
		      ht = y + 20;
		    }
		  }
			var pnl = $get('<%=pnl1.ClientID %>');
			if (ht < 200) ht = 200;
			if (ht > 620) ht = 620;
			if (wt > 1030) wt = 1030;
			if (wt < 400) wt = 400;
			pnl.height = ht;
			pnl.width = wt;
			$get('mboxtable').width = wt;
			$get('tdTitle').width = wt;
			o.height = ht;
			o.width = wt;
			$find('mpe1Box').show();
			return true;
		},
		resizeDiv: function(o) {
			var ht = 100;
			var wt = 400;
			var doc = $get([o.id]);
			if (doc) {
				ht = doc.offsetHeight;
				wt = doc.offsetWidth;
			}
			var pnl = $get('<%=pnl1.ClientID %>');

			if (ht < 100)
				ht = 100;
			if (ht > 450)
				ht = 450
			if (wt > 1000)
				wt = 1000
			if (wt < 400)
				wt = 400;
			pnl.height = ht;
			pnl.width = wt;
			$get('mboxtable').width = wt;
			$get('tdTitle').width = wt;
			o.style.height = ht + 'px';
			o.style.width = wt + 'px';
			return true;
		}
		
	}
</script>
<style>
  .lg-msg-box-outer{
    border-top-left-radius:6px;border-top-right-radius:6px;
   }
  .lg-msg-box{
    display:flex;flex-direction:row;justify-content:space-between;background-color:#0094ff;
     align-items:center;
 }
  .lg-msg-box>div{
    line-height:30px;
  }
</style>
<asp:Label ID="fakeButton" runat="server" Style="display: none"></asp:Label>
<asp:Panel ID="pnl1" runat="server" CssClass="lg-msg-box-outer" ClientIDMode="Static" BackColor="white" Style="display: none;">
  <div class="lg-msg-box lg-msg-box-outer" id="mboxtable">
    <div>
      <asp:Image ID="imgerr" runat="server" AlternateText="Message" ToolTip="Message" ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/Default/Images/Error1.gif" />
    </div>
    <div id="tdTitle" style="cursor: move;font-size:14px; font-weight: bold; color: White">
      Message
    </div>
    <div>
      <asp:ImageButton ID="cmdClose0" runat="server" Height="18px" Width="18px" ImageAlign="AbsMiddle" OnClientClick="return lgMessageBox.CancelMessage();" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
    </div>
  </div>
  <div id="dynamicData" enableviewstate="false" style="display: none;"></div>
  <iframe id="IfBd1" enableviewstate="false" style="display: none; border: none;"></iframe>
</asp:Panel>
<AJX:ModalPopupExtender ID="mPopup" RepositionMode="RepositionOnWindowResizeAndScroll" DropShadow="true" TargetControlID="fakeButton" BackgroundCssClass="modalBackground" BehaviorID="mpe1Box" CancelControlID="cmdClose0" OkControlID="cmdClose0" PopupControlID="pnl1" PopupDragHandleControlID="tdTitle" runat="server">
</AJX:ModalPopupExtender>
