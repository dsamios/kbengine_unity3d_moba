# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *

class FrameSyncReport(KBEngine.EntityComponent):
	def __init__(self):
		KBEngine.EntityComponent.__init__(self)

	def onAttached(self, owner):
		"""
		"""
		INFO_MSG("Operation::onAttached(): owner=%i" % (owner.id))

		self.getFrameSyncMgr().addPlayer(self)

	def onDetached(self, owner):
		"""
		"""
		INFO_MSG("Operation::onDetached(): owner=%i" % (owner.id))

		frameSyncMgr = self.getFrameSyncMgr()
		if frameSyncMgr is not None:
			frameSyncMgr.removePlayer(owner.id)

	def getFrameSyncMgr(self):
		"""
		获得当前space的entity baseEntityCall
		"""
		return KBEngine.cellAppData.get("FrameSyncMgr_%i" % self.owner.spaceID,None)

	def reportFrame(self,exposed,framedata):
		"""
		上传操作帧
		"""
		if exposed != self.ownerID:
			return

		#DEBUG_MSG("------FrameSyncReport------reportFrame.%i framedata:%s" % (self.ownerID,str(framedata)))

		self.getFrameSyncMgr().reportFrame(self.owner,framedata)

	# def adjustFrameId(self, frameId):
	# 	"""
	# 	调整逻辑帧的帧数
	# 	"""
	# 	if frameId > self.farmeID:
	# 		return
	# 	self.farmeID = frameId






