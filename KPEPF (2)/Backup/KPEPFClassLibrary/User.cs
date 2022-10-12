using System;
using System.Collections.Generic;
using System.Text;

namespace KPEPFClassLibrary
{
    public class User
    {
        #region fields
        private String chvPauNo;
        private int intDesigId;
            private int intUserTypeId;
            private string chvUser;
            private string chvPassword;
            private int intLBId;
        #endregion
        #region properties
            public String  ChvPauNo
            {
                get
                {
                    return this.chvPauNo;
                }
                set
                {
                    chvPauNo = value;
                }
            }
            public int IntDesigId
            {
                get
                {
                    return this.intDesigId;
                }
                set
                {
                    intDesigId = value;
                }
            }
            public int IntUserTypeId
            {
                get
                {
                    return this.intUserTypeId;
                }
                set
                {
                    intUserTypeId = value;
                }
            }
            public string ChvUser
            {
                get
                {
                    return this.chvUser;
                }
                set
                {
                    chvUser = value;
                }
            }
            public string ChvPassword
            {
                get
                {
                    return this.chvPassword;
                }
                set
                {
                    chvPassword = value;
                }
            }
            public int IntLBId
            {
                get
                {
                    return this.intLBId;
                }
                set
                {
                    intLBId = value;
                }
            }
        #endregion

    }
}
