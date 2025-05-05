// dart format width=80
// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'home_data_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$HomeDataDto implements DiagnosticableTreeMixin {

 int get id; String get name;
/// Create a copy of HomeDataDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$HomeDataDtoCopyWith<HomeDataDto> get copyWith => _$HomeDataDtoCopyWithImpl<HomeDataDto>(this as HomeDataDto, _$identity);

  /// Serializes this HomeDataDto to a JSON map.
  Map<String, dynamic> toJson();

@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeDataDto'))
    ..add(DiagnosticsProperty('id', id))..add(DiagnosticsProperty('name', name));
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is HomeDataDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name);

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeDataDto(id: $id, name: $name)';
}


}

/// @nodoc
abstract mixin class $HomeDataDtoCopyWith<$Res>  {
  factory $HomeDataDtoCopyWith(HomeDataDto value, $Res Function(HomeDataDto) _then) = _$HomeDataDtoCopyWithImpl;
@useResult
$Res call({
 int id, String name
});




}
/// @nodoc
class _$HomeDataDtoCopyWithImpl<$Res>
    implements $HomeDataDtoCopyWith<$Res> {
  _$HomeDataDtoCopyWithImpl(this._self, this._then);

  final HomeDataDto _self;
  final $Res Function(HomeDataDto) _then;

/// Create a copy of HomeDataDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = null,Object? name = null,}) {
  return _then(_self.copyWith(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: null == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String,
  ));
}

}


/// @nodoc
@JsonSerializable()

class _HomeDataDto with DiagnosticableTreeMixin implements HomeDataDto {
  const _HomeDataDto({required this.id, required this.name});
  factory _HomeDataDto.fromJson(Map<String, dynamic> json) => _$HomeDataDtoFromJson(json);

@override final  int id;
@override final  String name;

/// Create a copy of HomeDataDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$HomeDataDtoCopyWith<_HomeDataDto> get copyWith => __$HomeDataDtoCopyWithImpl<_HomeDataDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$HomeDataDtoToJson(this, );
}
@override
void debugFillProperties(DiagnosticPropertiesBuilder properties) {
  properties
    ..add(DiagnosticsProperty('type', 'HomeDataDto'))
    ..add(DiagnosticsProperty('id', id))..add(DiagnosticsProperty('name', name));
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _HomeDataDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name);

@override
String toString({ DiagnosticLevel minLevel = DiagnosticLevel.info }) {
  return 'HomeDataDto(id: $id, name: $name)';
}


}

/// @nodoc
abstract mixin class _$HomeDataDtoCopyWith<$Res> implements $HomeDataDtoCopyWith<$Res> {
  factory _$HomeDataDtoCopyWith(_HomeDataDto value, $Res Function(_HomeDataDto) _then) = __$HomeDataDtoCopyWithImpl;
@override @useResult
$Res call({
 int id, String name
});




}
/// @nodoc
class __$HomeDataDtoCopyWithImpl<$Res>
    implements _$HomeDataDtoCopyWith<$Res> {
  __$HomeDataDtoCopyWithImpl(this._self, this._then);

  final _HomeDataDto _self;
  final $Res Function(_HomeDataDto) _then;

/// Create a copy of HomeDataDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = null,Object? name = null,}) {
  return _then(_HomeDataDto(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: null == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String,
  ));
}


}

// dart format on
