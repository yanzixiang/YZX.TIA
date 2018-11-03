using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Controls;
using Siemens.Simatic.PlcLanguages.GraphEditor;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class GraphDrawSettingsProxy
  {
    internal GraphDrawSettings GraphDrawSettings;

    internal GraphDrawSettingsProxy(GraphDrawSettings settings)
    {
      GraphDrawSettings = settings;
    }

    public Font DefaultFont
    {
      get
      {
        return GraphDrawSettings.DefaultFont;
      }
    }

    public Pen ConnectionPenThin
    {
      get
      {
        return GraphDrawSettings.ConnectionPenThin;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPenThin", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectionPenSelectedThin
    {
      get
      {
        return GraphDrawSettings.ConnectionPenSelectedThin;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPenSelectedThin", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectionPenSelectionThin
    {
      get
      {
        return GraphDrawSettings.ConnectionPenSelectionThin;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPenSelectionThinInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush ConnectionBrush
    {
      get
      {
        return GraphDrawSettings.ConnectionBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush ConnectionBrushSelection
    {
      get
      {
        return GraphDrawSettings.ConnectionBrushSelection;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionBrushSelectionInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush ConnectionBrushSelected
    {
      get
      {
        return GraphDrawSettings.ConnectionBrushSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionBrushSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush PseudoDeletedBrush
    {
      get
      {
        return GraphDrawSettings.PseudoDeletedBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_PseudoDeletedBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen PseudoDeletedPen
    {
      get
      {
        return GraphDrawSettings.PseudoDeletedPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_PseudoDeletedPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SequenceFocusPen
    {
      get
      {
        return GraphDrawSettings.SequenceFocusPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InactiveFocusPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen FocusBackgroundPen
    {
      get
      {
        return GraphDrawSettings.FocusBackgroundPen;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InactiveFocusBackgroundPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen InactiveFocusBackgroundPen
    {
      get
      {
        return GraphDrawSettings.InactiveFocusBackgroundPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InactiveFocusBackgroundPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen InactiveFocusPen
    {
      get
      {
        return GraphDrawSettings.InactiveFocusPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InactiveFocusPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush SeqPaletteBrushSelected
    {
      get
      {
        return GraphDrawSettings.SeqPaletteBrushSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SeqPaletteBrushSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush SeqPaletteBrush
    {
      get
      {
        return GraphDrawSettings.SeqPaletteBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SeqPaletteBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SeqPaletteBorderPen
    {
      get
      {
        return GraphDrawSettings.SeqPaletteBorderPen;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SeqPaletteBorderPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font PaletteHeaderFont
    {
      get
      {
        return GraphDrawSettings.PaletteHeaderFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_PaletteHeaderFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color CommentForeColor
    {
      get
      {
        return GraphDrawSettings.CommentForeColor;
      }
    }

    public Brush CommentForeBrush
    {
      get
      {
        return GraphDrawSettings.CommentForeBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_CommentForeBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectionPen
    {
      get
      {
        return GraphDrawSettings.ConnectionPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectionPenSelected
    {
      get
      {
        return GraphDrawSettings.ConnectionPenSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPenSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectionPenSelection
    {
      get
      {
        return GraphDrawSettings.ConnectionPenSelection;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ConnectionPenSelectionInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush JumpTargetArrowBrush
    {
      get
      {
        return GraphDrawSettings.JumpTargetArrowBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_JumpTargetArrowBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font TransitionNumberFont
    {
      get
      {
        return GraphDrawSettings.TransitionNumberFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TransitionNumberFontPrint", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font TransitionNameFont
    {
      get
      {
        return GraphDrawSettings.TransitionNameFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TransitionNameFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font TransitionNumberFontBig
    {
      get
      {
        return GraphDrawSettings.TransitionNumberFontBig;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TransitionNumberFontBig", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font TransitionNameFontBig
    {
      get
      {
        return GraphDrawSettings.TransitionNameFontBig;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TransitionNameFontBig", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SimultaneousBranchPenSelected
    {
      get
      {
        return GraphDrawSettings.SimultaneousBranchPenSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SimultaneousBranchPenSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SimultaneousBranchPenSelection
    {
      get
      {
        return GraphDrawSettings.SimultaneousBranchPenSelection;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SimultaneousBranchPenSelectionInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepBackground
    {
      get
      {
        return GraphDrawSettings.StepBackground;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackground", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepBackgroundSelected
    {
      get
      {
        return GraphDrawSettings.StepBackgroundSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackgroundSelectedInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen StepMiddleLinePen
    {
      get
      {
        return GraphDrawSettings.StepMiddleLinePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepMiddleLinePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepForeBrushSelected
    {
      get
      {
        return GraphDrawSettings.StepForeBrushSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepForeBrushSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepForeBrushSymbolic
    {
      get
      {
        return GraphDrawSettings.StepForeBrushSymbolic;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepForeBrushSymbolic", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepForeBrushAbsolute
    {
      get
      {
        return GraphDrawSettings.StepForeBrushAbsolute;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepForeBrushAbsolute", value,
          ReflectionWays.SystemReflection);
      }
    }

    public StringFormat StepStringFormatLeftAligned
    {
      get
      {
        return GraphDrawSettings.StepStringFormatLeftAligned;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepStringFormatLeftAligned", value,
          ReflectionWays.SystemReflection);
      }
    }

    public StringFormat StepStringFormatCenterAligned
    {
      get
      {
        return GraphDrawSettings.StepStringFormatCenterAligned;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepStringFormatCenterAligned", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font StepNumberFont
    {
      get
      {
        return GraphDrawSettings.StepNumberFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNumberFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font StepNameFont
    {
      get
      {
        return GraphDrawSettings.StepNameFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNameFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font StepNumberFontBig
    {
      get
      {
        return GraphDrawSettings.StepNumberFontBig;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNumberFontBig", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font StepNameFontBig
    {
      get
      {
        return GraphDrawSettings.StepNameFontBig;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNameFontBig", value,
          ReflectionWays.SystemReflection);
      }
    }

    public StringFormat TransitionStringFormat
    {
      get
      {
        return GraphDrawSettings.TransitionStringFormat;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TransitionStringFormat", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color HighlightColor
    {
      get
      {
        return GraphDrawSettings.HighlightColor;
      }

    }

    public Brush HighlightBrush
    {
      get
      {
        return GraphDrawSettings.HighlightBrush;
      }
    }

    public Pen HighlightPen
    {
      get
      {
        return GraphDrawSettings.HighlightPen;
      }
    }

    public Brush HighlightIndicatorBrush
    {
      get
      {
        return GraphDrawSettings.HighlightIndicatorBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_MarkHighlightBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush HighlightFrameBrush
    {
      get
      {
        return GraphDrawSettings.HighlightFrameBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightFrameBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush MarkBrush
    {
      get
      {
        return GraphDrawSettings.MarkBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_MarkBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush MarkFrameBrush
    {
      get
      {
        return GraphDrawSettings.MarkFrameBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_MarkFrameBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush JumpHighlightBrush
    {
      get
      {
        return GraphDrawSettings.JumpHighlightBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_JumpHighlightBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen HighlightAreaFramePen
    {
      get
      {
        return GraphDrawSettings.HighlightAreaFramePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightAreaFramePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen HighlightAreaFramePenInactive
    {
      get
      {
        return GraphDrawSettings.HighlightAreaFramePenInactive;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightAreaFramePenInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color HighlightAreaFrameColor
    {
      get
      {
        return GraphDrawSettings.HighlightAreaFrameColor;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightAreaFrameColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color HighlightAreaFrameColorInactive
    {
      get
      {
        return GraphDrawSettings.HighlightAreaFrameColorInactive;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightAreaFrameColorInactive", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen MovingWirePen
    {
      get
      {
        return GraphDrawSettings.MovingWirePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_MovingWirePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen HighlightMovingWirePen
    {
      get
      {
        return GraphDrawSettings.HighlightMovingWirePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightMovingWirePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen HighlightMovingWirePenSim
    {
      get
      {
        return GraphDrawSettings.HighlightMovingWirePenSim;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightMovingWirePenSim", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AdjustableArrowCap HighlightMovingWireArrowCap
    {
      get
      {
        return GraphDrawSettings.HighlightMovingWireArrowCap;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_HighlightMovingWireArrowCap", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SetJumpTargetPenValid
    {
      get
      {
        return GraphDrawSettings.SetJumpTargetPenValid;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SetJumpTargetPenValid", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SetJumpTargetPenInvalid
    {
      get
      {
        return GraphDrawSettings.SetJumpTargetPenInvalid;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SetJumpTargetPenInvalid", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen AlarmViewForePen
    {
      get
      {
        return GraphDrawSettings.AlarmViewForePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmViewPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush AlarmViewForeBrush
    {
      get
      {
        return GraphDrawSettings.AlarmViewForeBrush;
      }
    }

    public Font AlarmViewFont
    {
      get
      {
        return GraphDrawSettings.AlarmViewFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmViewFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font AlarmTextFont
    {
      get
      {
        return GraphDrawSettings.AlarmTextFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmViewTextBoxFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font NavAlarmViewFont
    {
      get
      {
        return GraphDrawSettings.NavAlarmViewFont;
      }
    }

    public Color NavAlarmViewBackColor
    {
      get
      {
        return GraphDrawSettings.NavAlarmViewBackColor;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NavAlarmViewBackColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush NavAlarmViewBackBrush
    {
      get
      {
        return GraphDrawSettings.NavAlarmViewBackBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NavAlarmViewBackBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush AlarmTextBackBrush
    {
      get
      {
        return GraphDrawSettings.AlarmTextBackBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmTextBackBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush AlarmTextDisabledBrush
    {
      get
      {
        return GraphDrawSettings.AlarmTextDisabledBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmTextDisabledBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color AlarmTextBackColor
    {
      get
      {
        return GraphDrawSettings.AlarmTextBackColor ;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_AlarmTextBackColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color AlarmViewBackColor
    {
      get
      {
        return GraphDrawSettings.AlarmViewBackColor;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ViewBackColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineActiveBrush
    {
      get
      {
        return GraphDrawSettings.OnlineActiveBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineActiveBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineDisturbedBrush
    {
      get
      {
        return GraphDrawSettings.OnlineDisturbedBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineDisturbedBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineWarningBrush
    {
      get
      {
        return GraphDrawSettings.OnlineWarningBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineWarningBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineSyncProposalBrush
    {
      get
      {
        return GraphDrawSettings.OnlineSyncProposalBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineSyncProposalBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen OnlineActivePen
    {
      get
      {
        return GraphDrawSettings.OnlineActivePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineActivePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen OnlineActivePenThin
    {
      get
      {
        return GraphDrawSettings.OnlineActivePenThin;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineActivePenThin", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen OnlineActivePenSimBranchSelected
    {
      get
      {
        return GraphDrawSettings.OnlineActivePenSimBranchSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineActivePenSimBranchSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen OnlineDisturbedPenWarning
    {
      get
      {
        return GraphDrawSettings.OnlineDisturbedPenWarning;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineDisturbedPenWarning", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen OnlineDisturbedPenError
    {
      get
      {
        return GraphDrawSettings.OnlineDisturbedPenError;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineDisturbedPenError", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Font OnlineStepTimeFont
    {
      get
      {
        return GraphDrawSettings.OnlineStepTimeFont;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineStepTimeFont", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepTimeBrush
    {
      get
      {
        return GraphDrawSettings.OnlineStepTimeBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineStepTimeBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineNotMonitoredBrush
    {
      get
      {
        return GraphDrawSettings.OnlineNotMonitoredBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnlineNotMonitoredBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepForeBrushSelectedActive
    {
      get
      {
        return GraphDrawSettings.OnlineStepForeBrushSelectedActive;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackgroundSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepForeBrushSelectedWarning
    {
      get
      {
        return this.OnlineStepForeBrushSelectedActive;
      }
    }

    public Brush OnlineStepForeBrushSelectedError
    {
      get
      {
        return GraphDrawSettings.OnlineStepForeBrushSelectedError;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepForeBrushSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepBackBrushSelectedActive
    {
      get
      {
        return GraphDrawSettings.OnlineStepBackBrushSelectedActive;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackgroundSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepBackBrushSelectedWarning
    {
      get
      {
        return GraphDrawSettings.OnlineStepBackBrushSelectedWarning;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackgroundSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush OnlineStepBackBrushSelectedError
    {
      get
      {
        return GraphDrawSettings.OnlineStepBackBrushSelectedError;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepBackgroundSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepNotCompared
    {
      get
      {
        return GraphDrawSettings.StepNotCompared;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNotComparedBackground", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen StepNotComparedMiddleLinePen
    {
      get
      {
        return GraphDrawSettings.StepNotComparedMiddleLinePen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepNotComparedMiddleLinePen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen NotComparedConnectionPen
    {
      get
      {
        return GraphDrawSettings.NotComparedConnectionPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NotComparedConnectionPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen NotComparedConnectionPenThin
    {
      get
      {
        return GraphDrawSettings.NotComparedConnectionPenThin;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NotComparedConnectionPenThin", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush NotComparedConnectionBrush
    {
      get
      {
        return GraphDrawSettings.NotComparedConnectionBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NotComparedConnectionBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush NotComparedForeBrushAbsolute
    {
      get
      {
        return GraphDrawSettings.NotComparedForeBrushAbsolute;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NotComparedForeBrushAbsolute", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush NotComparedFontBrush
    {
      get
      {
        return GraphDrawSettings.NotComparedFontBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NotComparedFontBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen SimultaneousBranchComparePenSelected
    {
      get
      {
        return GraphDrawSettings.SimultaneousBranchComparePenSelected;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SimultaneousBranchComparePenSelected", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush StepTransNumberDifferenceBrush
    {
      get
      {
        return GraphDrawSettings.StepTransNumberDifferenceBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_StepTransNumberDifferenceBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush JumpDifferenceLilaBrush
    {
      get
      {
        return GraphDrawSettings.JumpDifferenceLilaBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_JumpDifferenceLilaBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush JumpDifferencePinkBrush
    {
      get
      {
        return GraphDrawSettings.JumpDifferencePinkBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_JumpDifferencePinkBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush CompareSelectionModeBrush
    {
      get
      {
        return GraphDrawSettings.CompareSelectionModeBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_CompareSelectionModeBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen JumpTargetPen
    {
      get
      {
        return GraphDrawSettings.JumpTargetPen;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_JumpTargetPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color ForeColor
    {
      get
      {
        return GraphDrawSettings.ForeColor;
      }
    }

    public Color InactiveSelectionColor
    {
      get
      {
        return GraphDrawSettings.InactiveSelectionColor;
      }
    }

    public Color InactiveBackColor
    {
      get
      {
        return GraphDrawSettings.InactiveBackColor;
      }
    }

    public Color SelectionColor
    {
      get
      {
        return GraphDrawSettings.SelectionColor;
      }
    }

    public Color SelectionFrontColor
    {
      get
      {
        return GraphDrawSettings.SelectionFrontColor;
      }
    }

    public Color SelectionBoxFrameColor
    {
      get
      {
        return GraphDrawSettings.SelectionBoxFrameColor;
      }
    }

    public Color SelectionBoxInsideColor
    {
      get
      {
        return GraphDrawSettings.SelectionBoxInsideColor;
      }
    }

    public Color JumpLineColor
    {
      get
      {
        return GraphDrawSettings.JumpLineColor;
      }
    }

    public Color FocusColor
    {
      get
      {
        return GraphDrawSettings.FocusColor;
      }
    }

    public Color BackColor
    {
      get
      {
        return GraphDrawSettings.BackColor;
      }
    }

    public Color NavigationViewBackColor
    {
      get
      {
        return GraphDrawSettings.NavigationViewBackColor;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ViewBackColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color NavigationViewActiveColor
    {
      get
      {
        return GraphDrawSettings.NavigationViewActiveColor;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NavigationViewActiveColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Color ConnectableBranchColor
    {
      get
      {
        return GraphDrawSettings.ConnectableBranchColor;
      }
    }

    public Color NotConnectableBranchColor
    {
      get
      {
        return GraphDrawSettings.NotConnectableBranchColor;
      }
    }

    public Color ReadOnlyColor
    {
      get
      {
        return GraphDrawSettings.ReadOnlyColor;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_ReadOnlyColor", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush FocusBrush
    {
      get
      {
        return GraphDrawSettings.FocusBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TreeFocusBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush ForeBrush
    {
      get
      {
        return GraphDrawSettings.ForeBrush;
      }
    }

    public Brush SelectionBrush
    {
      get
      {
        return GraphDrawSettings.SelectionBrush;
      }
    }

    public Brush SelectionFrontBrush
    {
      get
      {
        return GraphDrawSettings.SelectionFrontBrush;
      }
    }

    public Brush SelectionBoxInsideBrush
    {
      get
      {
        return GraphDrawSettings.SelectionBoxInsideBrush;
      }
    }

    public Brush HoverBrush
    {
      get
      {
        return GraphDrawSettings.HoverBrush;
      }
    }

    public Brush NavigationViewActiveBrush
    {
      get
      {
        return GraphDrawSettings.NavigationViewActiveBrush;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_NavigationViewActiveBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush NavigationViewBackBrush
    {
      get
      {
        return GraphDrawSettings.NavigationViewBackBrush;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InactiveFocusBackgroundPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Brush SelectedTextBackgroundBrush
    {
      get
      {
        return GraphDrawSettings.SelectedTextBackgroundBrush;
      }
    }

    public Brush SelectedTextForegroundBrush
    {
      get
      {
        return GraphDrawSettings.SelectedTextForegroundBrush;
      }
    }

    public Pen ForePen
    {
      get
      {
        return GraphDrawSettings.ForePen;
      }
    }

    public Pen SelectionPen
    {
      get
      {
        return GraphDrawSettings.SelectionPen;
      }
    }

    public Pen NavigationViewPermOpSelectionPen
    {
      get
      {
        return GraphDrawSettings.NavigationViewPermOpSelectionPen;
      }
    }

    public Pen SelectionFrontPen
    {
      get
      {
        return GraphDrawSettings.SelectionFrontPen;
      }
    }

    public Pen SelectionBoxFramePen
    {
      get
      {
        return GraphDrawSettings.SelectionBoxFramePen;
      }
    }

    public Pen JumpLinePen
    {
      get
      {
        return GraphDrawSettings.JumpLinePen;
      }
    }

    public Pen FocusPen
    {
      get
      {
        return GraphDrawSettings.FocusPen;
      }
    }

    public Pen FocusPenForTreeItems
    {
      get
      {
        return GraphDrawSettings.FocusPenForTreeItems;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_TreeFocusPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen ConnectableBranchPen
    {
      get
      {
        return GraphDrawSettings.ConnectableBranchPen;
      }
    }

    public Pen NotConnectableBranchPen
    {
      get
      {
        return GraphDrawSettings.NotConnectableBranchPen;
      }
    }

    public Pen DottedLineTransitionPen
    {
      get
      {
        return GraphDrawSettings.DottedLineTransitionPen;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_DottedLineTransitionPen", value,
          ReflectionWays.SystemReflection);
      }
    }

    public Pen DottedLineTogglerPen
    {
      get
      {
        return GraphDrawSettings.DottedLineTogglerPen;
      }

      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_DottedLineTogglerPen", value,
          ReflectionWays.SystemReflection);
      }
    }

#region ICON
    public AccessibleIcon SupervisionErrorIcon
    {
      get
      {
        return GraphDrawSettings.SupervisionErrorIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_SupervisionErrorIcon", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AccessibleIcon InterlockWarningIcon
    {
      get
      {
        return GraphDrawSettings.InterlockWarningIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_InterlockWarningIcon", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AccessibleIcon OnEqualIcon
    {
      get
      {
        return GraphDrawSettings.OnEqualIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnEqualIcon", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AccessibleIcon OnUnEqualIcon
    {
      get
      {
        return GraphDrawSettings.OnUnEqualIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OnUnEqualIcon", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AccessibleIcon OffUnequalIcon
    {
      get
      {
        return GraphDrawSettings.OffUnequalIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_OffUnequalIcon", value,
          ReflectionWays.SystemReflection);
      }
    }

    public AccessibleIcon EmptyIcon
    {
      get
      {
        return GraphDrawSettings.EmptyIcon;
      }
      set
      {
        Reflector.SetInstanceFieldByName(GraphDrawSettings, "m_MarkHighlightBrush", value,
          ReflectionWays.SystemReflection);
      }
    }

#endregion ICON
  }
}
