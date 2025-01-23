namespace Bridge
{

    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon Coupon = null;

        public abstract int CalculatePrice();

        protected Menu(ICoupon coupon)
        {
            Coupon = coupon;
        }
    }

    /// <summary>
    /// Refined Abstraction
    /// </summary>
    public class VegetarianMenu: Menu
    {
        public VegetarianMenu(ICoupon coupon): base(coupon)
        {
            
        }

        public override int CalculatePrice()
        {
            return 20 - Coupon.CouponValue;
        }
    }

    /// <summary>
    /// Refined Abstraction
    /// </summary>
    public class MeatBasedMenu: Menu
    {
        public MeatBasedMenu(ICoupon coupon): base(coupon)
        {
            
        }

        public override int CalculatePrice()
        {
            return 30 - Coupon.CouponValue;
        }
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        int CouponValue { get; }
    }

    /// <summary>
    /// ConcretImplementor
    /// </summary>
    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }

    public class OneEuroCoupon: ICoupon
    {
        public int CouponValue => 1;
    }

    public class TwoEuroCoupon: ICoupon
    {
        public int CouponValue => 2;
    }
}