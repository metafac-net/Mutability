using Shouldly;
using Xunit;

namespace MetaFac.Mutability.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateFrozenFromMutable()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = new() { Field1 = 456 };
            freezable.IsFrozen().ShouldBeFalse();
            freezable.CopyFrom(mutable);
            freezable.Freeze();
            freezable.IsFrozen().ShouldBeTrue();
            freezable.Field1.ShouldBe(mutable.Field1);
        }
        [Fact]
        public void CreateFrozenViaExtension()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = mutable.Unfrozen<SampleFreezable, ISample>();
            freezable.IsFrozen().ShouldBeFalse();
            freezable.Freeze();
            freezable.IsFrozen().ShouldBeTrue();
            freezable.Field1.ShouldBe(mutable.Field1);
        }
        [Fact]
        public void CreateFrozenViaCloning()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 }.Frozen();
            SampleFreezable copy = orig.Unfrozen().Frozen();
            copy.IsFrozen().ShouldBeTrue();
            copy.Field1.ShouldBe(orig.Field1);
            copy.Equals(orig).ShouldBeTrue();
        }
#if NET5_0_OR_GREATER
        [Fact]
        public void CreateRecordViaCloning()
        {
            SampleRecord orig = new() { Field1 = 123 };
            SampleRecord copy = new(orig);
            copy.IsFrozen().ShouldBeTrue();
            copy.Field1.ShouldBe(orig.Field1);
            copy.Equals(orig).ShouldBeTrue();
            copy.ShouldBe(orig);
        }
        [Fact]
        public void CreateRecordFromFreezable()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 };
            orig = orig.Frozen();
            SampleRecord copy = new(orig);
            copy.IsFrozen().ShouldBeTrue();
            copy.Field1.ShouldBe(orig.Field1);
        }
#endif
    }
}