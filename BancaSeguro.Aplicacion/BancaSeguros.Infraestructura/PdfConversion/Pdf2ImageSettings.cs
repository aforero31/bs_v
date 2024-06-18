
using System.ComponentModel;

namespace BancaSeguros.Infraestructura.PdfConversion
{
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class Pdf2ImageSettings : INotifyPropertyChanged
  {
  #region  Private Member Declarations  

    private GhostScript.AntiAliasMode _antiAliasMode;
    private int _dpi;
    private GhostScript.GridFitMode _gridFitMode;
    private GhostScript.ImageFormat _imageFormat;
    private GhostScript.PaperSize _paperSize;
    private GhostScript.PdfTrimMode _trimMode;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    public Pdf2ImageSettings()
    {
      this.Dpi = 150;
      this.GridFitMode = GhostScript.GridFitMode.Topological;
      this.AntiAliasMode = GhostScript.AntiAliasMode.High;
      this.ImageFormat = GhostScript.ImageFormat.Png24;
      this.PaperSize = GhostScript.PaperSize.Default;
      this.TrimMode = GhostScript.PdfTrimMode.CropBox;
    }

  #endregion  Public Constructors  

  #region  Events  

    public event PropertyChangedEventHandler PropertyChanged;

  #endregion  Events  

  #region  Public Properties  

    [DefaultValue(typeof(GhostScript.AntiAliasMode), "High")]
    public GhostScript.AntiAliasMode AntiAliasMode
    {
      get { return _antiAliasMode; }
      set
      {
        if (this.AntiAliasMode != value)
        {
          _antiAliasMode = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("AntiAliasMode"));
        }
      }
    }

    [DefaultValue(150)]
    public int Dpi
    {
      get { return _dpi; }
      set
      {
        if (this.Dpi != value)
        {
          _dpi = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("Dpi"));
        }
      }
    }

    [DefaultValue(typeof(GhostScript.GridFitMode), "Topological")]
    public GhostScript.GridFitMode GridFitMode
    {
      get { return _gridFitMode; }
      set
      {
        if (this.GridFitMode != value)
        {
          _gridFitMode = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("GridFitMode"));
        }
      }
    }

    [DefaultValue(typeof(GhostScript.ImageFormat), "Png24")]
    public GhostScript.ImageFormat ImageFormat
    {
      get { return _imageFormat; }
      set
      {
        if (this.ImageFormat != value)
        {
          _imageFormat = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("ImageFormat"));
        }
      }
    }

    [DefaultValue(typeof(GhostScript.PaperSize), "Default")]
    public GhostScript.PaperSize PaperSize
    {
      get { return _paperSize; }
      set
      {
        if (this.PaperSize != value)
        {
          _paperSize = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("PaperSize"));
        }
      }
    }

    [DefaultValue(typeof(GhostScript.PdfTrimMode), "CropBox")]
    public GhostScript.PdfTrimMode TrimMode
    {
      get { return _trimMode; }
      set
      {
        if (this.TrimMode != value)
        {
          _trimMode = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs("TrimMode"));
        }
      }
    }

  #endregion  Public Properties  

  #region  Protected Methods  

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, e);
    }

  #endregion  Protected Methods  
  }
}
