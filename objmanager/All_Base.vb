Imports LATIR2.Utils

Namespace Document

    Public MustInherit Class All_Base
        Implements IDisposable

        Protected m_ID As Guid

        Public Overridable Property ID() As Guid
            Get
                Return m_ID
            End Get
            Set(ByVal V As Guid)
                m_ID = V
            End Set
        End Property

      



        Public MustOverride Property Parent() As DocCollection_Base
        

        Public MustOverride Property Application() As Doc_Base
      

        Public Overridable ReadOnly Property CanChange() As Boolean
            Get
                Return True
            End Get

        End Property

        Public MustOverride Sub Dispose() Implements System.IDisposable.Dispose

    End Class
End Namespace

