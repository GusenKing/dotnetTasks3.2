// dart format width=80
// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'home_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;
/// @nodoc
mixin _$HomeState implements DiagnosticableTreeMixin {




@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeState'))
    ;
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is HomeState);
}


@override
int get hashCode => runtimeType.hashCode;

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeState()';
}


}

/// @nodoc
class $HomeStateCopyWith<$Res>  {
$HomeStateCopyWith(HomeState _, $Res Function(HomeState) __);
}


/// @nodoc


class Loading with DiagnosticableTreeMixin implements HomeState {
  const Loading();
  





@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeState.loading'))
    ;
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is Loading);
}


@override
int get hashCode => runtimeType.hashCode;

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeState.loading()';
}


}




/// @nodoc


class Error with DiagnosticableTreeMixin implements HomeState {
  const Error(this.message);
  

 final  String message;

/// Create a copy of HomeState
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$ErrorCopyWith<Error> get copyWith => _$ErrorCopyWithImpl<Error>(this, _$identity);


@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeState.error'))
    ..add(DiagnosticsProperty('message', message));
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is Error&&(identical(other.message, message) || other.message == message));
}


@override
int get hashCode => Object.hash(runtimeType,message);

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeState.error(message: $message)';
}


}

/// @nodoc
abstract mixin class $ErrorCopyWith<$Res> implements $HomeStateCopyWith<$Res> {
  factory $ErrorCopyWith(Error value, $Res Function(Error) _then) = _$ErrorCopyWithImpl;
@useResult
$Res call({
 String message
});




}
/// @nodoc
class _$ErrorCopyWithImpl<$Res>
    implements $ErrorCopyWith<$Res> {
  _$ErrorCopyWithImpl(this._self, this._then);

  final Error _self;
  final $Res Function(Error) _then;

/// Create a copy of HomeState
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') $Res call({Object? message = null,}) {
  return _then(Error(
null == message ? _self.message : message // ignore: cast_nullable_to_non_nullable
as String,
  ));
}


}

/// @nodoc


class Normal with DiagnosticableTreeMixin implements HomeState {
  const Normal({required final  List<HomeDataDto> data1, required this.isLoading1, required final  List<HomeDataDto> data2, required this.isLoading2}): _data1 = data1,_data2 = data2;
  

 final  List<HomeDataDto> _data1;
 List<HomeDataDto> get data1 {
  if (_data1 is EqualUnmodifiableListView) return _data1;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(_data1);
}

 final  bool isLoading1;
 final  List<HomeDataDto> _data2;
 List<HomeDataDto> get data2 {
  if (_data2 is EqualUnmodifiableListView) return _data2;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(_data2);
}

 final  bool isLoading2;

/// Create a copy of HomeState
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$NormalCopyWith<Normal> get copyWith => _$NormalCopyWithImpl<Normal>(this, _$identity);


@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeState.normal'))
    ..add(DiagnosticsProperty('data1', data1))..add(DiagnosticsProperty('isLoading1', isLoading1))..add(DiagnosticsProperty('data2', data2))..add(DiagnosticsProperty('isLoading2', isLoading2));
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is Normal&&const DeepCollectionEquality().equals(other._data1, _data1)&&(identical(other.isLoading1, isLoading1) || other.isLoading1 == isLoading1)&&const DeepCollectionEquality().equals(other._data2, _data2)&&(identical(other.isLoading2, isLoading2) || other.isLoading2 == isLoading2));
}


@override
int get hashCode => Object.hash(runtimeType,const DeepCollectionEquality().hash(_data1),isLoading1,const DeepCollectionEquality().hash(_data2),isLoading2);

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeState.normal(data1: $data1, isLoading1: $isLoading1, data2: $data2, isLoading2: $isLoading2)';
}


}

/// @nodoc
abstract mixin class $NormalCopyWith<$Res> implements $HomeStateCopyWith<$Res> {
  factory $NormalCopyWith(Normal value, $Res Function(Normal) _then) = _$NormalCopyWithImpl;
@useResult
$Res call({
 List<HomeDataDto> data1, bool isLoading1, List<HomeDataDto> data2, bool isLoading2
});




}
/// @nodoc
class _$NormalCopyWithImpl<$Res>
    implements $NormalCopyWith<$Res> {
  _$NormalCopyWithImpl(this._self, this._then);

  final Normal _self;
  final $Res Function(Normal) _then;

/// Create a copy of HomeState
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') $Res call({Object? data1 = null,Object? isLoading1 = null,Object? data2 = null,Object? isLoading2 = null,}) {
  return _then(Normal(
data1: null == data1 ? _self._data1 : data1 // ignore: cast_nullable_to_non_nullable
as List<HomeDataDto>,isLoading1: null == isLoading1 ? _self.isLoading1 : isLoading1 // ignore: cast_nullable_to_non_nullable
as bool,data2: null == data2 ? _self._data2 : data2 // ignore: cast_nullable_to_non_nullable
as List<HomeDataDto>,isLoading2: null == isLoading2 ? _self.isLoading2 : isLoading2 // ignore: cast_nullable_to_non_nullable
as bool,
  ));
}


}

// dart format on
