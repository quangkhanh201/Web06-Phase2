﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CUKCUK.Common.Enum
{
    public enum Operator
    {
        /// <summary>
        /// Chứa
        /// </summary>
        Contain = 0,

        /// <summary>
        /// Bằng
        /// </summary>
        Equal = 1,

        /// <summary>
        /// Bắt đầu bằng
        /// </summary>
        Start_With = 2,

        /// <summary>
        /// Kết thúc bằng
        /// </summary>
        End_With = 3,

        /// <summary>
        /// Không chứa
        /// </summary>
        Not_Contain = 4,

        /// <summary>
        /// Nhỏ hơn
        /// </summary>
        Less = 5,

        /// <summary>
        /// Lớn hơn
        /// </summary>
        Bigger = 6,

        /// <summary>
        /// Nhỏ hơn hoặc bằng
        /// </summary>
        Less_Or_Equal = 7,

        /// <summary>
        /// Lớn hơn hoặc bằng
        /// </summary>
        Bigger_Or_Equal = 8
    }
}
