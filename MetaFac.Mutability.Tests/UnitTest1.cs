using FluentAssertions;
using Xunit;

namespace MetaFac.Mutability.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateFrozen1()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = new() { Field1 = 456 };
            freezable.IsFrozen().Should().BeFalse();
            freezable.CopyFrom(mutable);
            freezable.Freeze();
            freezable.IsFrozen().Should().BeTrue();
            freezable.Field1.Should().Be(mutable.Field1);
        }
        [Fact]
        public void CreateFrozen2()
        {
            SampleMutable immutable = new() { Field1 = 123 };
            SampleFreezable freezable = SampleFreezable.Create((x) => x.CopyFrom(immutable));
            freezable.IsFrozen().Should().BeTrue();
            freezable.Field1.Should().Be(immutable.Field1);
        }
        [Fact]
        public void CreateFrozen3()
        {
            SampleMutable mutable = new() { Field1 = 123 };
            SampleFreezable freezable = mutable.Unfrozen<SampleFreezable, ISample>();
            freezable.IsFrozen().Should().BeFalse();
            freezable.Freeze();
            freezable.IsFrozen().Should().BeTrue();
            freezable.Field1.Should().Be(mutable.Field1);
        }
        [Fact]
        public void CreateFrozen4()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 }.Frozen();
            SampleFreezable copy = orig.Unfrozen().Frozen();
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
            copy.Equals(orig).Should().BeTrue();
        }
#if NET5_0_OR_GREATER
        [Fact]
        public void CreateRecord1()
        {
            SampleRecord orig = new() { Field1 = 123 };
            SampleRecord copy = new(orig);
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
            copy.Equals(orig).Should().BeTrue();
        }
        [Fact]
        public void CreateRecord2()
        {
            SampleFreezable orig = new SampleFreezable() { Field1 = 123 }.Frozen();
            SampleRecord copy = new(orig);
            copy.IsFrozen().Should().BeTrue();
            copy.Field1.Should().Be(orig.Field1);
        }
#endif
    }
}