using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorGui {
    public interface IValueView {
        ushort Get();
        void Set(ushort value);

    }
}
