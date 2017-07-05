using System;
using CoreFoundation;
using CoreGraphics;
using CoreText;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace YYKit.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull YYTextBackedStringAttributeName __attribute__((visibility("default")));
		[Field ("YYTextBackedStringAttributeName", "__Internal")]
		NSString YYTextBackedStringAttributeName { get; }

		// extern NSString *const _Nonnull YYTextBindingAttributeName __attribute__((visibility("default")));
		[Field ("YYTextBindingAttributeName", "__Internal")]
		NSString YYTextBindingAttributeName { get; }

		// extern NSString *const _Nonnull YYTextShadowAttributeName __attribute__((visibility("default")));
		[Field ("YYTextShadowAttributeName", "__Internal")]
		NSString YYTextShadowAttributeName { get; }

		// extern NSString *const _Nonnull YYTextInnerShadowAttributeName __attribute__((visibility("default")));
		[Field ("YYTextInnerShadowAttributeName", "__Internal")]
		NSString YYTextInnerShadowAttributeName { get; }

		// extern NSString *const _Nonnull YYTextUnderlineAttributeName __attribute__((visibility("default")));
		[Field ("YYTextUnderlineAttributeName", "__Internal")]
		NSString YYTextUnderlineAttributeName { get; }

		// extern NSString *const _Nonnull YYTextStrikethroughAttributeName __attribute__((visibility("default")));
		[Field ("YYTextStrikethroughAttributeName", "__Internal")]
		NSString YYTextStrikethroughAttributeName { get; }

		// extern NSString *const _Nonnull YYTextBorderAttributeName __attribute__((visibility("default")));
		[Field ("YYTextBorderAttributeName", "__Internal")]
		NSString YYTextBorderAttributeName { get; }

		// extern NSString *const _Nonnull YYTextBackgroundBorderAttributeName __attribute__((visibility("default")));
		[Field ("YYTextBackgroundBorderAttributeName", "__Internal")]
		NSString YYTextBackgroundBorderAttributeName { get; }

		// extern NSString *const _Nonnull YYTextBlockBorderAttributeName __attribute__((visibility("default")));
		[Field ("YYTextBlockBorderAttributeName", "__Internal")]
		NSString YYTextBlockBorderAttributeName { get; }

		// extern NSString *const _Nonnull YYTextAttachmentAttributeName __attribute__((visibility("default")));
		[Field ("YYTextAttachmentAttributeName", "__Internal")]
		NSString YYTextAttachmentAttributeName { get; }

		// extern NSString *const _Nonnull YYTextHighlightAttributeName __attribute__((visibility("default")));
		[Field ("YYTextHighlightAttributeName", "__Internal")]
		NSString YYTextHighlightAttributeName { get; }

		// extern NSString *const _Nonnull YYTextGlyphTransformAttributeName __attribute__((visibility("default")));
		[Field ("YYTextGlyphTransformAttributeName", "__Internal")]
		NSString YYTextGlyphTransformAttributeName { get; }

		// extern NSString *const _Nonnull YYTextAttachmentToken __attribute__((visibility("default")));
		[Field ("YYTextAttachmentToken", "__Internal")]
		NSString YYTextAttachmentToken { get; }

		// extern NSString *const _Nonnull YYTextTruncationToken __attribute__((visibility("default")));
		[Field ("YYTextTruncationToken", "__Internal")]
		NSString YYTextTruncationToken { get; }
	}

	// typedef void (^YYTextAction)(UIView * _Nonnull, NSAttributedString * _Nonnull, NSRange, CGRect);
	delegate void YYTextAction (UIView arg0, NSAttributedString arg1, NSRange arg2, CGRect arg3);

	// @interface YYTextBackedString : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextBackedString : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)stringWithString:(NSString * _Nullable)string;
		[Static]
		[Export ("stringWithString:")]
		YYTextBackedString StringWithString ([NullAllowed] string @string);

		// @property (copy, nonatomic) NSString * _Nullable string;
		[NullAllowed, Export ("string")]
		string String { get; set; }
	}

	// @interface YYTextBinding : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextBinding : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)bindingWithDeleteConfirm:(BOOL)deleteConfirm;
		[Static]
		[Export ("bindingWithDeleteConfirm:")]
		YYTextBinding BindingWithDeleteConfirm (bool deleteConfirm);

		// @property (nonatomic) BOOL deleteConfirm;
		[Export ("deleteConfirm")]
		bool DeleteConfirm { get; set; }
	}

	// @interface YYTextShadow : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextShadow : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)shadowWithColor:(UIColor * _Nullable)color offset:(CGSize)offset radius:(CGFloat)radius;
		[Static]
		[Export ("shadowWithColor:offset:radius:")]
		YYTextShadow ShadowWithColor ([NullAllowed] UIColor color, CGSize offset, nfloat radius);

		// @property (nonatomic, strong) UIColor * _Nullable color;
		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// @property (nonatomic) CGSize offset;
		[Export ("offset", ArgumentSemantic.Assign)]
		CGSize Offset { get; set; }

		// @property (nonatomic) CGFloat radius;
		[Export ("radius")]
		nfloat Radius { get; set; }

		// @property (nonatomic) CGBlendMode blendMode;
		[Export ("blendMode", ArgumentSemantic.Assign)]
		CGBlendMode BlendMode { get; set; }

		// @property (nonatomic, strong) YYTextShadow * _Nullable subShadow;
		[NullAllowed, Export ("subShadow", ArgumentSemantic.Strong)]
		YYTextShadow SubShadow { get; set; }

		// +(instancetype _Nonnull)shadowWithNSShadow:(NSShadow * _Nonnull)nsShadow;
		[Static]
		[Export ("shadowWithNSShadow:")]
		YYTextShadow ShadowWithNSShadow (NSShadow nsShadow);

		// -(NSShadow * _Nonnull)nsShadow;
		[Export ("nsShadow")]
		[Verify (MethodToProperty)]
		NSShadow NsShadow { get; }
	}

	// @interface YYTextDecoration : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextDecoration : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)decorationWithStyle:(YYTextLineStyle)style;
		[Static]
		[Export ("decorationWithStyle:")]
		YYTextDecoration DecorationWithStyle (YYTextLineStyle style);

		// +(instancetype _Nonnull)decorationWithStyle:(YYTextLineStyle)style width:(NSNumber * _Nullable)width color:(UIColor * _Nullable)color;
		[Static]
		[Export ("decorationWithStyle:width:color:")]
		YYTextDecoration DecorationWithStyle (YYTextLineStyle style, [NullAllowed] NSNumber width, [NullAllowed] UIColor color);

		// @property (nonatomic) YYTextLineStyle style;
		[Export ("style", ArgumentSemantic.Assign)]
		YYTextLineStyle Style { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable width;
		[NullAllowed, Export ("width", ArgumentSemantic.Strong)]
		NSNumber Width { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable color;
		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// @property (nonatomic, strong) YYTextShadow * _Nullable shadow;
		[NullAllowed, Export ("shadow", ArgumentSemantic.Strong)]
		YYTextShadow Shadow { get; set; }
	}

	// @interface YYTextBorder : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextBorder : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)borderWithLineStyle:(YYTextLineStyle)lineStyle lineWidth:(CGFloat)width strokeColor:(UIColor * _Nullable)color;
		[Static]
		[Export ("borderWithLineStyle:lineWidth:strokeColor:")]
		YYTextBorder BorderWithLineStyle (YYTextLineStyle lineStyle, nfloat width, [NullAllowed] UIColor color);

		// +(instancetype _Nonnull)borderWithFillColor:(UIColor * _Nullable)color cornerRadius:(CGFloat)cornerRadius;
		[Static]
		[Export ("borderWithFillColor:cornerRadius:")]
		YYTextBorder BorderWithFillColor ([NullAllowed] UIColor color, nfloat cornerRadius);

		// @property (nonatomic) YYTextLineStyle lineStyle;
		[Export ("lineStyle", ArgumentSemantic.Assign)]
		YYTextLineStyle LineStyle { get; set; }

		// @property (nonatomic) CGFloat strokeWidth;
		[Export ("strokeWidth")]
		nfloat StrokeWidth { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable strokeColor;
		[NullAllowed, Export ("strokeColor", ArgumentSemantic.Strong)]
		UIColor StrokeColor { get; set; }

		// @property (nonatomic) CGLineJoin lineJoin;
		[Export ("lineJoin", ArgumentSemantic.Assign)]
		CGLineJoin LineJoin { get; set; }

		// @property (nonatomic) UIEdgeInsets insets;
		[Export ("insets", ArgumentSemantic.Assign)]
		UIEdgeInsets Insets { get; set; }

		// @property (nonatomic) CGFloat cornerRadius;
		[Export ("cornerRadius")]
		nfloat CornerRadius { get; set; }

		// @property (nonatomic, strong) YYTextShadow * _Nullable shadow;
		[NullAllowed, Export ("shadow", ArgumentSemantic.Strong)]
		YYTextShadow Shadow { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable fillColor;
		[NullAllowed, Export ("fillColor", ArgumentSemantic.Strong)]
		UIColor FillColor { get; set; }
	}

	// @interface YYTextAttachment : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextAttachment : INSCoding, INSCopying
	{
		// +(instancetype _Nonnull)attachmentWithContent:(id _Nullable)content;
		[Static]
		[Export ("attachmentWithContent:")]
		YYTextAttachment AttachmentWithContent ([NullAllowed] NSObject content);

		// @property (nonatomic, strong) id _Nullable content;
		[NullAllowed, Export ("content", ArgumentSemantic.Strong)]
		NSObject Content { get; set; }

		// @property (nonatomic) UIViewContentMode contentMode;
		[Export ("contentMode", ArgumentSemantic.Assign)]
		UIViewContentMode ContentMode { get; set; }

		// @property (nonatomic) UIEdgeInsets contentInsets;
		[Export ("contentInsets", ArgumentSemantic.Assign)]
		UIEdgeInsets ContentInsets { get; set; }

		// @property (nonatomic, strong) NSDictionary * _Nullable userInfo;
		[NullAllowed, Export ("userInfo", ArgumentSemantic.Strong)]
		NSDictionary UserInfo { get; set; }
	}

	// @interface YYTextHighlight : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface YYTextHighlight : INSCoding, INSCopying
	{
		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
		[NullAllowed, Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Attributes { get; set; }

		// +(instancetype _Nonnull)highlightWithAttributes:(NSDictionary<NSString *,id> * _Nullable)attributes;
		[Static]
		[Export ("highlightWithAttributes:")]
		YYTextHighlight HighlightWithAttributes ([NullAllowed] NSDictionary<NSString, NSObject> attributes);

		// +(instancetype _Nonnull)highlightWithBackgroundColor:(UIColor * _Nullable)color;
		[Static]
		[Export ("highlightWithBackgroundColor:")]
		YYTextHighlight HighlightWithBackgroundColor ([NullAllowed] UIColor color);

		// -(void)setFont:(UIFont * _Nullable)font;
		[Export ("setFont:")]
		void SetFont ([NullAllowed] UIFont font);

		// -(void)setColor:(UIColor * _Nullable)color;
		[Export ("setColor:")]
		void SetColor ([NullAllowed] UIColor color);

		// -(void)setStrokeWidth:(NSNumber * _Nullable)width;
		[Export ("setStrokeWidth:")]
		void SetStrokeWidth ([NullAllowed] NSNumber width);

		// -(void)setStrokeColor:(UIColor * _Nullable)color;
		[Export ("setStrokeColor:")]
		void SetStrokeColor ([NullAllowed] UIColor color);

		// -(void)setShadow:(YYTextShadow * _Nullable)shadow;
		[Export ("setShadow:")]
		void SetShadow ([NullAllowed] YYTextShadow shadow);

		// -(void)setInnerShadow:(YYTextShadow * _Nullable)shadow;
		[Export ("setInnerShadow:")]
		void SetInnerShadow ([NullAllowed] YYTextShadow shadow);

		// -(void)setUnderline:(YYTextDecoration * _Nullable)underline;
		[Export ("setUnderline:")]
		void SetUnderline ([NullAllowed] YYTextDecoration underline);

		// -(void)setStrikethrough:(YYTextDecoration * _Nullable)strikethrough;
		[Export ("setStrikethrough:")]
		void SetStrikethrough ([NullAllowed] YYTextDecoration strikethrough);

		// -(void)setBackgroundBorder:(YYTextBorder * _Nullable)border;
		[Export ("setBackgroundBorder:")]
		void SetBackgroundBorder ([NullAllowed] YYTextBorder border);

		// -(void)setBorder:(YYTextBorder * _Nullable)border;
		[Export ("setBorder:")]
		void SetBorder ([NullAllowed] YYTextBorder border);

		// -(void)setAttachment:(YYTextAttachment * _Nullable)attachment;
		[Export ("setAttachment:")]
		void SetAttachment ([NullAllowed] YYTextAttachment attachment);

		// @property (copy, nonatomic) NSDictionary * _Nullable userInfo;
		[NullAllowed, Export ("userInfo", ArgumentSemantic.Copy)]
		NSDictionary UserInfo { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable tapAction;
		[NullAllowed, Export ("tapAction", ArgumentSemantic.Copy)]
		YYTextAction TapAction { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable longPressAction;
		[NullAllowed, Export ("longPressAction", ArgumentSemantic.Copy)]
		YYTextAction LongPressAction { get; set; }
	}

	// @interface YYText (NSAttributedString)
	[Category]
	[BaseType (typeof(NSAttributedString))]
	interface NSAttributedString_YYText
	{
		// -(NSData * _Nullable)archiveToData;
		[NullAllowed, Export ("archiveToData")]
		[Verify (MethodToProperty)]
		NSData ArchiveToData { get; }

		// +(instancetype _Nullable)unarchiveFromData:(NSData * _Nonnull)data;
		[Static]
		[Export ("unarchiveFromData:")]
		[return: NullAllowed]
		NSAttributedString UnarchiveFromData (NSData data);

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
		[NullAllowed, Export ("attributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(NSDictionary<NSString *,id> * _Nullable)attributesAtIndex:(NSUInteger)index;
		[Export ("attributesAtIndex:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> AttributesAtIndex (nuint index);

		// -(id _Nullable)attribute:(NSString * _Nonnull)attributeName atIndex:(NSUInteger)index;
		[Export ("attribute:atIndex:")]
		[return: NullAllowed]
		NSObject Attribute (string attributeName, nuint index);

		// @property (readonly, nonatomic, strong) UIFont * _Nullable font;
		[NullAllowed, Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; }

		// -(UIFont * _Nullable)fontAtIndex:(NSUInteger)index;
		[Export ("fontAtIndex:")]
		[return: NullAllowed]
		UIFont FontAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable kern;
		[NullAllowed, Export ("kern", ArgumentSemantic.Strong)]
		NSNumber Kern { get; }

		// -(NSNumber * _Nullable)kernAtIndex:(NSUInteger)index;
		[Export ("kernAtIndex:")]
		[return: NullAllowed]
		NSNumber KernAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) UIColor * _Nullable color;
		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; }

		// -(UIColor * _Nullable)colorAtIndex:(NSUInteger)index;
		[Export ("colorAtIndex:")]
		[return: NullAllowed]
		UIColor ColorAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; }

		// -(UIColor * _Nullable)backgroundColorAtIndex:(NSUInteger)index;
		[Export ("backgroundColorAtIndex:")]
		[return: NullAllowed]
		UIColor BackgroundColorAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable strokeWidth;
		[NullAllowed, Export ("strokeWidth", ArgumentSemantic.Strong)]
		NSNumber StrokeWidth { get; }

		// -(NSNumber * _Nullable)strokeWidthAtIndex:(NSUInteger)index;
		[Export ("strokeWidthAtIndex:")]
		[return: NullAllowed]
		NSNumber StrokeWidthAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) UIColor * _Nullable strokeColor;
		[NullAllowed, Export ("strokeColor", ArgumentSemantic.Strong)]
		UIColor StrokeColor { get; }

		// -(UIColor * _Nullable)strokeColorAtIndex:(NSUInteger)index;
		[Export ("strokeColorAtIndex:")]
		[return: NullAllowed]
		UIColor StrokeColorAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSShadow * _Nullable shadow;
		[NullAllowed, Export ("shadow", ArgumentSemantic.Strong)]
		NSShadow Shadow { get; }

		// -(NSShadow * _Nullable)shadowAtIndex:(NSUInteger)index;
		[Export ("shadowAtIndex:")]
		[return: NullAllowed]
		NSShadow ShadowAtIndex (nuint index);

		// @property (readonly, nonatomic) NSUnderlineStyle strikethroughStyle;
		[Export ("strikethroughStyle")]
		NSUnderlineStyle StrikethroughStyle { get; }

		// -(NSUnderlineStyle)strikethroughStyleAtIndex:(NSUInteger)index;
		[Export ("strikethroughStyleAtIndex:")]
		NSUnderlineStyle StrikethroughStyleAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) UIColor * _Nullable strikethroughColor;
		[NullAllowed, Export ("strikethroughColor", ArgumentSemantic.Strong)]
		UIColor StrikethroughColor { get; }

		// -(UIColor * _Nullable)strikethroughColorAtIndex:(NSUInteger)index;
		[Export ("strikethroughColorAtIndex:")]
		[return: NullAllowed]
		UIColor StrikethroughColorAtIndex (nuint index);

		// @property (readonly, nonatomic) NSUnderlineStyle underlineStyle;
		[Export ("underlineStyle")]
		NSUnderlineStyle UnderlineStyle { get; }

		// -(NSUnderlineStyle)underlineStyleAtIndex:(NSUInteger)index;
		[Export ("underlineStyleAtIndex:")]
		NSUnderlineStyle UnderlineStyleAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) UIColor * _Nullable underlineColor;
		[NullAllowed, Export ("underlineColor", ArgumentSemantic.Strong)]
		UIColor UnderlineColor { get; }

		// -(UIColor * _Nullable)underlineColorAtIndex:(NSUInteger)index;
		[Export ("underlineColorAtIndex:")]
		[return: NullAllowed]
		UIColor UnderlineColorAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable ligature;
		[NullAllowed, Export ("ligature", ArgumentSemantic.Strong)]
		NSNumber Ligature { get; }

		// -(NSNumber * _Nullable)ligatureAtIndex:(NSUInteger)index;
		[Export ("ligatureAtIndex:")]
		[return: NullAllowed]
		NSNumber LigatureAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSString * _Nullable textEffect;
		[NullAllowed, Export ("textEffect", ArgumentSemantic.Strong)]
		string TextEffect { get; }

		// -(NSString * _Nullable)textEffectAtIndex:(NSUInteger)index;
		[Export ("textEffectAtIndex:")]
		[return: NullAllowed]
		string TextEffectAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable obliqueness;
		[NullAllowed, Export ("obliqueness", ArgumentSemantic.Strong)]
		NSNumber Obliqueness { get; }

		// -(NSNumber * _Nullable)obliquenessAtIndex:(NSUInteger)index;
		[Export ("obliquenessAtIndex:")]
		[return: NullAllowed]
		NSNumber ObliquenessAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable expansion;
		[NullAllowed, Export ("expansion", ArgumentSemantic.Strong)]
		NSNumber Expansion { get; }

		// -(NSNumber * _Nullable)expansionAtIndex:(NSUInteger)index;
		[Export ("expansionAtIndex:")]
		[return: NullAllowed]
		NSNumber ExpansionAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable baselineOffset;
		[NullAllowed, Export ("baselineOffset", ArgumentSemantic.Strong)]
		NSNumber BaselineOffset { get; }

		// -(NSNumber * _Nullable)baselineOffsetAtIndex:(NSUInteger)index;
		[Export ("baselineOffsetAtIndex:")]
		[return: NullAllowed]
		NSNumber BaselineOffsetAtIndex (nuint index);

		// @property (readonly, nonatomic) BOOL verticalGlyphForm;
		[Export ("verticalGlyphForm")]
		bool VerticalGlyphForm { get; }

		// -(BOOL)verticalGlyphFormAtIndex:(NSUInteger)index;
		[Export ("verticalGlyphFormAtIndex:")]
		bool VerticalGlyphFormAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSString * _Nullable language;
		[NullAllowed, Export ("language", ArgumentSemantic.Strong)]
		string Language { get; }

		// -(NSString * _Nullable)languageAtIndex:(NSUInteger)index;
		[Export ("languageAtIndex:")]
		[return: NullAllowed]
		string LanguageAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSArray<NSNumber *> * _Nullable writingDirection;
		[NullAllowed, Export ("writingDirection", ArgumentSemantic.Strong)]
		NSNumber[] WritingDirection { get; }

		// -(NSArray<NSNumber *> * _Nullable)writingDirectionAtIndex:(NSUInteger)index;
		[Export ("writingDirectionAtIndex:")]
		[return: NullAllowed]
		NSNumber[] WritingDirectionAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) NSParagraphStyle * _Nullable paragraphStyle;
		[NullAllowed, Export ("paragraphStyle", ArgumentSemantic.Strong)]
		NSParagraphStyle ParagraphStyle { get; }

		// -(NSParagraphStyle * _Nullable)paragraphStyleAtIndex:(NSUInteger)index;
		[Export ("paragraphStyleAtIndex:")]
		[return: NullAllowed]
		NSParagraphStyle ParagraphStyleAtIndex (nuint index);

		// @property (readonly, nonatomic) NSTextAlignment alignment;
		[Export ("alignment")]
		NSTextAlignment Alignment { get; }

		// -(NSTextAlignment)alignmentAtIndex:(NSUInteger)index;
		[Export ("alignmentAtIndex:")]
		NSTextAlignment AlignmentAtIndex (nuint index);

		// @property (readonly, nonatomic) NSLineBreakMode lineBreakMode;
		[Export ("lineBreakMode")]
		NSLineBreakMode LineBreakMode { get; }

		// -(NSLineBreakMode)lineBreakModeAtIndex:(NSUInteger)index;
		[Export ("lineBreakModeAtIndex:")]
		NSLineBreakMode LineBreakModeAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat lineSpacing;
		[Export ("lineSpacing")]
		nfloat LineSpacing { get; }

		// -(CGFloat)lineSpacingAtIndex:(NSUInteger)index;
		[Export ("lineSpacingAtIndex:")]
		nfloat LineSpacingAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat paragraphSpacing;
		[Export ("paragraphSpacing")]
		nfloat ParagraphSpacing { get; }

		// -(CGFloat)paragraphSpacingAtIndex:(NSUInteger)index;
		[Export ("paragraphSpacingAtIndex:")]
		nfloat ParagraphSpacingAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat paragraphSpacingBefore;
		[Export ("paragraphSpacingBefore")]
		nfloat ParagraphSpacingBefore { get; }

		// -(CGFloat)paragraphSpacingBeforeAtIndex:(NSUInteger)index;
		[Export ("paragraphSpacingBeforeAtIndex:")]
		nfloat ParagraphSpacingBeforeAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat firstLineHeadIndent;
		[Export ("firstLineHeadIndent")]
		nfloat FirstLineHeadIndent { get; }

		// -(CGFloat)firstLineHeadIndentAtIndex:(NSUInteger)index;
		[Export ("firstLineHeadIndentAtIndex:")]
		nfloat FirstLineHeadIndentAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat headIndent;
		[Export ("headIndent")]
		nfloat HeadIndent { get; }

		// -(CGFloat)headIndentAtIndex:(NSUInteger)index;
		[Export ("headIndentAtIndex:")]
		nfloat HeadIndentAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat tailIndent;
		[Export ("tailIndent")]
		nfloat TailIndent { get; }

		// -(CGFloat)tailIndentAtIndex:(NSUInteger)index;
		[Export ("tailIndentAtIndex:")]
		nfloat TailIndentAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat minimumLineHeight;
		[Export ("minimumLineHeight")]
		nfloat MinimumLineHeight { get; }

		// -(CGFloat)minimumLineHeightAtIndex:(NSUInteger)index;
		[Export ("minimumLineHeightAtIndex:")]
		nfloat MinimumLineHeightAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat maximumLineHeight;
		[Export ("maximumLineHeight")]
		nfloat MaximumLineHeight { get; }

		// -(CGFloat)maximumLineHeightAtIndex:(NSUInteger)index;
		[Export ("maximumLineHeightAtIndex:")]
		nfloat MaximumLineHeightAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat lineHeightMultiple;
		[Export ("lineHeightMultiple")]
		nfloat LineHeightMultiple { get; }

		// -(CGFloat)lineHeightMultipleAtIndex:(NSUInteger)index;
		[Export ("lineHeightMultipleAtIndex:")]
		nfloat LineHeightMultipleAtIndex (nuint index);

		// @property (readonly, nonatomic) NSWritingDirection baseWritingDirection;
		[Export ("baseWritingDirection")]
		NSWritingDirection BaseWritingDirection { get; }

		// -(NSWritingDirection)baseWritingDirectionAtIndex:(NSUInteger)index;
		[Export ("baseWritingDirectionAtIndex:")]
		NSWritingDirection BaseWritingDirectionAtIndex (nuint index);

		// @property (readonly, nonatomic) float hyphenationFactor;
		[Export ("hyphenationFactor")]
		float HyphenationFactor { get; }

		// -(float)hyphenationFactorAtIndex:(NSUInteger)index;
		[Export ("hyphenationFactorAtIndex:")]
		float HyphenationFactorAtIndex (nuint index);

		// @property (readonly, nonatomic) CGFloat defaultTabInterval;
		[Export ("defaultTabInterval")]
		nfloat DefaultTabInterval { get; }

		// -(CGFloat)defaultTabIntervalAtIndex:(NSUInteger)index;
		[Export ("defaultTabIntervalAtIndex:")]
		nfloat DefaultTabIntervalAtIndex (nuint index);

		// @property (readonly, copy, nonatomic) NSArray<NSTextTab *> * _Nullable tabStops;
		[NullAllowed, Export ("tabStops", ArgumentSemantic.Copy)]
		NSTextTab[] TabStops { get; }

		// -(NSArray<NSTextTab *> * _Nullable)tabStopsAtIndex:(NSUInteger)index;
		[Export ("tabStopsAtIndex:")]
		[return: NullAllowed]
		NSTextTab[] TabStopsAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextShadow * _Nullable textShadow;
		[NullAllowed, Export ("textShadow", ArgumentSemantic.Strong)]
		YYTextShadow TextShadow { get; }

		// -(YYTextShadow * _Nullable)textShadowAtIndex:(NSUInteger)index;
		[Export ("textShadowAtIndex:")]
		[return: NullAllowed]
		YYTextShadow TextShadowAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextShadow * _Nullable textInnerShadow;
		[NullAllowed, Export ("textInnerShadow", ArgumentSemantic.Strong)]
		YYTextShadow TextInnerShadow { get; }

		// -(YYTextShadow * _Nullable)textInnerShadowAtIndex:(NSUInteger)index;
		[Export ("textInnerShadowAtIndex:")]
		[return: NullAllowed]
		YYTextShadow TextInnerShadowAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextDecoration * _Nullable textUnderline;
		[NullAllowed, Export ("textUnderline", ArgumentSemantic.Strong)]
		YYTextDecoration TextUnderline { get; }

		// -(YYTextDecoration * _Nullable)textUnderlineAtIndex:(NSUInteger)index;
		[Export ("textUnderlineAtIndex:")]
		[return: NullAllowed]
		YYTextDecoration TextUnderlineAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextDecoration * _Nullable textStrikethrough;
		[NullAllowed, Export ("textStrikethrough", ArgumentSemantic.Strong)]
		YYTextDecoration TextStrikethrough { get; }

		// -(YYTextDecoration * _Nullable)textStrikethroughAtIndex:(NSUInteger)index;
		[Export ("textStrikethroughAtIndex:")]
		[return: NullAllowed]
		YYTextDecoration TextStrikethroughAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextBorder * _Nullable textBorder;
		[NullAllowed, Export ("textBorder", ArgumentSemantic.Strong)]
		YYTextBorder TextBorder { get; }

		// -(YYTextBorder * _Nullable)textBorderAtIndex:(NSUInteger)index;
		[Export ("textBorderAtIndex:")]
		[return: NullAllowed]
		YYTextBorder TextBorderAtIndex (nuint index);

		// @property (readonly, nonatomic, strong) YYTextBorder * _Nullable textBackgroundBorder;
		[NullAllowed, Export ("textBackgroundBorder", ArgumentSemantic.Strong)]
		YYTextBorder TextBackgroundBorder { get; }

		// -(YYTextBorder * _Nullable)textBackgroundBorderAtIndex:(NSUInteger)index;
		[Export ("textBackgroundBorderAtIndex:")]
		[return: NullAllowed]
		YYTextBorder TextBackgroundBorderAtIndex (nuint index);

		// @property (readonly, nonatomic) CGAffineTransform textGlyphTransform;
		[Export ("textGlyphTransform")]
		CGAffineTransform TextGlyphTransform { get; }

		// -(CGAffineTransform)textGlyphTransformAtIndex:(NSUInteger)index;
		[Export ("textGlyphTransformAtIndex:")]
		CGAffineTransform TextGlyphTransformAtIndex (nuint index);

		// -(NSString * _Nullable)plainTextForRange:(NSRange)range;
		[Export ("plainTextForRange:")]
		[return: NullAllowed]
		string PlainTextForRange (NSRange range);

		// +(NSMutableAttributedString * _Nonnull)attachmentStringWithContent:(id _Nullable)content contentMode:(UIViewContentMode)contentMode width:(CGFloat)width ascent:(CGFloat)ascent descent:(CGFloat)descent;
		[Static]
		[Export ("attachmentStringWithContent:contentMode:width:ascent:descent:")]
		NSMutableAttributedString AttachmentStringWithContent ([NullAllowed] NSObject content, UIViewContentMode contentMode, nfloat width, nfloat ascent, nfloat descent);

		// +(NSMutableAttributedString * _Nonnull)attachmentStringWithContent:(id _Nullable)content contentMode:(UIViewContentMode)contentMode attachmentSize:(CGSize)attachmentSize alignToFont:(UIFont * _Nonnull)font alignment:(YYTextVerticalAlignment)alignment;
		[Static]
		[Export ("attachmentStringWithContent:contentMode:attachmentSize:alignToFont:alignment:")]
		NSMutableAttributedString AttachmentStringWithContent ([NullAllowed] NSObject content, UIViewContentMode contentMode, CGSize attachmentSize, UIFont font, YYTextVerticalAlignment alignment);

		// +(NSMutableAttributedString * _Nullable)attachmentStringWithEmojiImage:(UIImage * _Nonnull)image fontSize:(CGFloat)fontSize;
		[Static]
		[Export ("attachmentStringWithEmojiImage:fontSize:")]
		[return: NullAllowed]
		NSMutableAttributedString AttachmentStringWithEmojiImage (UIImage image, nfloat fontSize);

		// -(NSRange)rangeOfAll;
		[Export ("rangeOfAll")]
		[Verify (MethodToProperty)]
		NSRange RangeOfAll { get; }

		// -(BOOL)isSharedAttributesInAllRange;
		[Export ("isSharedAttributesInAllRange")]
		[Verify (MethodToProperty)]
		bool IsSharedAttributesInAllRange { get; }

		// -(BOOL)canDrawWithUIKit;
		[Export ("canDrawWithUIKit")]
		[Verify (MethodToProperty)]
		bool CanDrawWithUIKit { get; }
	}

	// @interface YYText (NSMutableAttributedString)
	[Category]
	[BaseType (typeof(NSMutableAttributedString))]
	interface NSMutableAttributedString_YYText
	{
		// -(void)setAttributes:(NSDictionary<NSString *,id> * _Nullable)attributes;
		[Export ("setAttributes:")]
		void SetAttributes ([NullAllowed] NSDictionary<NSString, NSObject> attributes);

		// -(void)setAttribute:(NSString * _Nonnull)name value:(id _Nullable)value;
		[Export ("setAttribute:value:")]
		void SetAttribute (string name, [NullAllowed] NSObject value);

		// -(void)setAttribute:(NSString * _Nonnull)name value:(id _Nullable)value range:(NSRange)range;
		[Export ("setAttribute:value:range:")]
		void SetAttribute (string name, [NullAllowed] NSObject value, NSRange range);

		// -(void)removeAttributesInRange:(NSRange)range;
		[Export ("removeAttributesInRange:")]
		void RemoveAttributesInRange (NSRange range);

		// @property (readwrite, nonatomic, strong) UIFont * _Nullable font;
		[NullAllowed, Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// -(void)setFont:(UIFont * _Nullable)font range:(NSRange)range;
		[Export ("setFont:range:")]
		void SetFont ([NullAllowed] UIFont font, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable kern;
		[NullAllowed, Export ("kern", ArgumentSemantic.Strong)]
		NSNumber Kern { get; set; }

		// -(void)setKern:(NSNumber * _Nullable)kern range:(NSRange)range;
		[Export ("setKern:range:")]
		void SetKern ([NullAllowed] NSNumber kern, NSRange range);

		// @property (readwrite, nonatomic, strong) UIColor * _Nullable color;
		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// -(void)setColor:(UIColor * _Nullable)color range:(NSRange)range;
		[Export ("setColor:range:")]
		void SetColor ([NullAllowed] UIColor color, NSRange range);

		// @property (readwrite, nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// -(void)setBackgroundColor:(UIColor * _Nullable)backgroundColor range:(NSRange)range;
		[Export ("setBackgroundColor:range:")]
		void SetBackgroundColor ([NullAllowed] UIColor backgroundColor, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable strokeWidth;
		[NullAllowed, Export ("strokeWidth", ArgumentSemantic.Strong)]
		NSNumber StrokeWidth { get; set; }

		// -(void)setStrokeWidth:(NSNumber * _Nullable)strokeWidth range:(NSRange)range;
		[Export ("setStrokeWidth:range:")]
		void SetStrokeWidth ([NullAllowed] NSNumber strokeWidth, NSRange range);

		// @property (readwrite, nonatomic, strong) UIColor * _Nullable strokeColor;
		[NullAllowed, Export ("strokeColor", ArgumentSemantic.Strong)]
		UIColor StrokeColor { get; set; }

		// -(void)setStrokeColor:(UIColor * _Nullable)strokeColor range:(NSRange)range;
		[Export ("setStrokeColor:range:")]
		void SetStrokeColor ([NullAllowed] UIColor strokeColor, NSRange range);

		// @property (readwrite, nonatomic, strong) NSShadow * _Nullable shadow;
		[NullAllowed, Export ("shadow", ArgumentSemantic.Strong)]
		NSShadow Shadow { get; set; }

		// -(void)setShadow:(NSShadow * _Nullable)shadow range:(NSRange)range;
		[Export ("setShadow:range:")]
		void SetShadow ([NullAllowed] NSShadow shadow, NSRange range);

		// @property (readwrite, nonatomic) NSUnderlineStyle strikethroughStyle;
		[Export ("strikethroughStyle", ArgumentSemantic.Assign)]
		NSUnderlineStyle StrikethroughStyle { get; set; }

		// -(void)setStrikethroughStyle:(NSUnderlineStyle)strikethroughStyle range:(NSRange)range;
		[Export ("setStrikethroughStyle:range:")]
		void SetStrikethroughStyle (NSUnderlineStyle strikethroughStyle, NSRange range);

		// @property (readwrite, nonatomic, strong) UIColor * _Nullable strikethroughColor;
		[NullAllowed, Export ("strikethroughColor", ArgumentSemantic.Strong)]
		UIColor StrikethroughColor { get; set; }

		// -(void)setStrikethroughColor:(UIColor * _Nullable)strikethroughColor range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setStrikethroughColor:range:")]
		void SetStrikethroughColor ([NullAllowed] UIColor strikethroughColor, NSRange range);

		// @property (readwrite, nonatomic) NSUnderlineStyle underlineStyle;
		[Export ("underlineStyle", ArgumentSemantic.Assign)]
		NSUnderlineStyle UnderlineStyle { get; set; }

		// -(void)setUnderlineStyle:(NSUnderlineStyle)underlineStyle range:(NSRange)range;
		[Export ("setUnderlineStyle:range:")]
		void SetUnderlineStyle (NSUnderlineStyle underlineStyle, NSRange range);

		// @property (readwrite, nonatomic, strong) UIColor * _Nullable underlineColor;
		[NullAllowed, Export ("underlineColor", ArgumentSemantic.Strong)]
		UIColor UnderlineColor { get; set; }

		// -(void)setUnderlineColor:(UIColor * _Nullable)underlineColor range:(NSRange)range;
		[Export ("setUnderlineColor:range:")]
		void SetUnderlineColor ([NullAllowed] UIColor underlineColor, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable ligature;
		[NullAllowed, Export ("ligature", ArgumentSemantic.Strong)]
		NSNumber Ligature { get; set; }

		// -(void)setLigature:(NSNumber * _Nullable)ligature range:(NSRange)range;
		[Export ("setLigature:range:")]
		void SetLigature ([NullAllowed] NSNumber ligature, NSRange range);

		// @property (readwrite, nonatomic, strong) NSString * _Nullable textEffect;
		[NullAllowed, Export ("textEffect", ArgumentSemantic.Strong)]
		string TextEffect { get; set; }

		// -(void)setTextEffect:(NSString * _Nullable)textEffect range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setTextEffect:range:")]
		void SetTextEffect ([NullAllowed] string textEffect, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable obliqueness;
		[NullAllowed, Export ("obliqueness", ArgumentSemantic.Strong)]
		NSNumber Obliqueness { get; set; }

		// -(void)setObliqueness:(NSNumber * _Nullable)obliqueness range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setObliqueness:range:")]
		void SetObliqueness ([NullAllowed] NSNumber obliqueness, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable expansion;
		[NullAllowed, Export ("expansion", ArgumentSemantic.Strong)]
		NSNumber Expansion { get; set; }

		// -(void)setExpansion:(NSNumber * _Nullable)expansion range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setExpansion:range:")]
		void SetExpansion ([NullAllowed] NSNumber expansion, NSRange range);

		// @property (readwrite, nonatomic, strong) NSNumber * _Nullable baselineOffset;
		[NullAllowed, Export ("baselineOffset", ArgumentSemantic.Strong)]
		NSNumber BaselineOffset { get; set; }

		// -(void)setBaselineOffset:(NSNumber * _Nullable)baselineOffset range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setBaselineOffset:range:")]
		void SetBaselineOffset ([NullAllowed] NSNumber baselineOffset, NSRange range);

		// @property (readwrite, nonatomic) BOOL verticalGlyphForm;
		[Export ("verticalGlyphForm")]
		bool VerticalGlyphForm { get; set; }

		// -(void)setVerticalGlyphForm:(BOOL)verticalGlyphForm range:(NSRange)range;
		[Export ("setVerticalGlyphForm:range:")]
		void SetVerticalGlyphForm (bool verticalGlyphForm, NSRange range);

		// @property (readwrite, nonatomic, strong) NSString * _Nullable language;
		[NullAllowed, Export ("language", ArgumentSemantic.Strong)]
		string Language { get; set; }

		// -(void)setLanguage:(NSString * _Nullable)language range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setLanguage:range:")]
		void SetLanguage ([NullAllowed] string language, NSRange range);

		// @property (readwrite, nonatomic, strong) NSArray<NSNumber *> * _Nullable writingDirection;
		[NullAllowed, Export ("writingDirection", ArgumentSemantic.Strong)]
		NSNumber[] WritingDirection { get; set; }

		// -(void)setWritingDirection:(NSArray<NSNumber *> * _Nullable)writingDirection range:(NSRange)range;
		[Export ("setWritingDirection:range:")]
		void SetWritingDirection ([NullAllowed] NSNumber[] writingDirection, NSRange range);

		// @property (readwrite, nonatomic, strong) NSParagraphStyle * _Nullable paragraphStyle;
		[NullAllowed, Export ("paragraphStyle", ArgumentSemantic.Strong)]
		NSParagraphStyle ParagraphStyle { get; set; }

		// -(void)setParagraphStyle:(NSParagraphStyle * _Nullable)paragraphStyle range:(NSRange)range;
		[Export ("setParagraphStyle:range:")]
		void SetParagraphStyle ([NullAllowed] NSParagraphStyle paragraphStyle, NSRange range);

		// @property (readwrite, nonatomic) NSTextAlignment alignment;
		[Export ("alignment", ArgumentSemantic.Assign)]
		NSTextAlignment Alignment { get; set; }

		// -(void)setAlignment:(NSTextAlignment)alignment range:(NSRange)range;
		[Export ("setAlignment:range:")]
		void SetAlignment (NSTextAlignment alignment, NSRange range);

		// @property (readwrite, nonatomic) NSLineBreakMode lineBreakMode;
		[Export ("lineBreakMode", ArgumentSemantic.Assign)]
		NSLineBreakMode LineBreakMode { get; set; }

		// -(void)setLineBreakMode:(NSLineBreakMode)lineBreakMode range:(NSRange)range;
		[Export ("setLineBreakMode:range:")]
		void SetLineBreakMode (NSLineBreakMode lineBreakMode, NSRange range);

		// @property (readwrite, nonatomic) CGFloat lineSpacing;
		[Export ("lineSpacing")]
		nfloat LineSpacing { get; set; }

		// -(void)setLineSpacing:(CGFloat)lineSpacing range:(NSRange)range;
		[Export ("setLineSpacing:range:")]
		void SetLineSpacing (nfloat lineSpacing, NSRange range);

		// @property (readwrite, nonatomic) CGFloat paragraphSpacing;
		[Export ("paragraphSpacing")]
		nfloat ParagraphSpacing { get; set; }

		// -(void)setParagraphSpacing:(CGFloat)paragraphSpacing range:(NSRange)range;
		[Export ("setParagraphSpacing:range:")]
		void SetParagraphSpacing (nfloat paragraphSpacing, NSRange range);

		// @property (readwrite, nonatomic) CGFloat paragraphSpacingBefore;
		[Export ("paragraphSpacingBefore")]
		nfloat ParagraphSpacingBefore { get; set; }

		// -(void)setParagraphSpacingBefore:(CGFloat)paragraphSpacingBefore range:(NSRange)range;
		[Export ("setParagraphSpacingBefore:range:")]
		void SetParagraphSpacingBefore (nfloat paragraphSpacingBefore, NSRange range);

		// @property (readwrite, nonatomic) CGFloat firstLineHeadIndent;
		[Export ("firstLineHeadIndent")]
		nfloat FirstLineHeadIndent { get; set; }

		// -(void)setFirstLineHeadIndent:(CGFloat)firstLineHeadIndent range:(NSRange)range;
		[Export ("setFirstLineHeadIndent:range:")]
		void SetFirstLineHeadIndent (nfloat firstLineHeadIndent, NSRange range);

		// @property (readwrite, nonatomic) CGFloat headIndent;
		[Export ("headIndent")]
		nfloat HeadIndent { get; set; }

		// -(void)setHeadIndent:(CGFloat)headIndent range:(NSRange)range;
		[Export ("setHeadIndent:range:")]
		void SetHeadIndent (nfloat headIndent, NSRange range);

		// @property (readwrite, nonatomic) CGFloat tailIndent;
		[Export ("tailIndent")]
		nfloat TailIndent { get; set; }

		// -(void)setTailIndent:(CGFloat)tailIndent range:(NSRange)range;
		[Export ("setTailIndent:range:")]
		void SetTailIndent (nfloat tailIndent, NSRange range);

		// @property (readwrite, nonatomic) CGFloat minimumLineHeight;
		[Export ("minimumLineHeight")]
		nfloat MinimumLineHeight { get; set; }

		// -(void)setMinimumLineHeight:(CGFloat)minimumLineHeight range:(NSRange)range;
		[Export ("setMinimumLineHeight:range:")]
		void SetMinimumLineHeight (nfloat minimumLineHeight, NSRange range);

		// @property (readwrite, nonatomic) CGFloat maximumLineHeight;
		[Export ("maximumLineHeight")]
		nfloat MaximumLineHeight { get; set; }

		// -(void)setMaximumLineHeight:(CGFloat)maximumLineHeight range:(NSRange)range;
		[Export ("setMaximumLineHeight:range:")]
		void SetMaximumLineHeight (nfloat maximumLineHeight, NSRange range);

		// @property (readwrite, nonatomic) CGFloat lineHeightMultiple;
		[Export ("lineHeightMultiple")]
		nfloat LineHeightMultiple { get; set; }

		// -(void)setLineHeightMultiple:(CGFloat)lineHeightMultiple range:(NSRange)range;
		[Export ("setLineHeightMultiple:range:")]
		void SetLineHeightMultiple (nfloat lineHeightMultiple, NSRange range);

		// @property (readwrite, nonatomic) NSWritingDirection baseWritingDirection;
		[Export ("baseWritingDirection", ArgumentSemantic.Assign)]
		NSWritingDirection BaseWritingDirection { get; set; }

		// -(void)setBaseWritingDirection:(NSWritingDirection)baseWritingDirection range:(NSRange)range;
		[Export ("setBaseWritingDirection:range:")]
		void SetBaseWritingDirection (NSWritingDirection baseWritingDirection, NSRange range);

		// @property (readwrite, nonatomic) float hyphenationFactor;
		[Export ("hyphenationFactor")]
		float HyphenationFactor { get; set; }

		// -(void)setHyphenationFactor:(float)hyphenationFactor range:(NSRange)range;
		[Export ("setHyphenationFactor:range:")]
		void SetHyphenationFactor (float hyphenationFactor, NSRange range);

		// @property (readwrite, nonatomic) CGFloat defaultTabInterval;
		[Export ("defaultTabInterval")]
		nfloat DefaultTabInterval { get; set; }

		// -(void)setDefaultTabInterval:(CGFloat)defaultTabInterval range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setDefaultTabInterval:range:")]
		void SetDefaultTabInterval (nfloat defaultTabInterval, NSRange range);

		// @property (readwrite, copy, nonatomic) NSArray<NSTextTab *> * _Nullable tabStops;
		[NullAllowed, Export ("tabStops", ArgumentSemantic.Copy)]
		NSTextTab[] TabStops { get; set; }

		// -(void)setTabStops:(NSArray<NSTextTab *> * _Nullable)tabStops range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setTabStops:range:")]
		void SetTabStops ([NullAllowed] NSTextTab[] tabStops, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextShadow * _Nullable textShadow;
		[NullAllowed, Export ("textShadow", ArgumentSemantic.Strong)]
		YYTextShadow TextShadow { get; set; }

		// -(void)setTextShadow:(YYTextShadow * _Nullable)textShadow range:(NSRange)range;
		[Export ("setTextShadow:range:")]
		void SetTextShadow ([NullAllowed] YYTextShadow textShadow, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextShadow * _Nullable textInnerShadow;
		[NullAllowed, Export ("textInnerShadow", ArgumentSemantic.Strong)]
		YYTextShadow TextInnerShadow { get; set; }

		// -(void)setTextInnerShadow:(YYTextShadow * _Nullable)textInnerShadow range:(NSRange)range;
		[Export ("setTextInnerShadow:range:")]
		void SetTextInnerShadow ([NullAllowed] YYTextShadow textInnerShadow, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextDecoration * _Nullable textUnderline;
		[NullAllowed, Export ("textUnderline", ArgumentSemantic.Strong)]
		YYTextDecoration TextUnderline { get; set; }

		// -(void)setTextUnderline:(YYTextDecoration * _Nullable)textUnderline range:(NSRange)range;
		[Export ("setTextUnderline:range:")]
		void SetTextUnderline ([NullAllowed] YYTextDecoration textUnderline, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextDecoration * _Nullable textStrikethrough;
		[NullAllowed, Export ("textStrikethrough", ArgumentSemantic.Strong)]
		YYTextDecoration TextStrikethrough { get; set; }

		// -(void)setTextStrikethrough:(YYTextDecoration * _Nullable)textStrikethrough range:(NSRange)range;
		[Export ("setTextStrikethrough:range:")]
		void SetTextStrikethrough ([NullAllowed] YYTextDecoration textStrikethrough, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextBorder * _Nullable textBorder;
		[NullAllowed, Export ("textBorder", ArgumentSemantic.Strong)]
		YYTextBorder TextBorder { get; set; }

		// -(void)setTextBorder:(YYTextBorder * _Nullable)textBorder range:(NSRange)range;
		[Export ("setTextBorder:range:")]
		void SetTextBorder ([NullAllowed] YYTextBorder textBorder, NSRange range);

		// @property (readwrite, nonatomic, strong) YYTextBorder * _Nullable textBackgroundBorder;
		[NullAllowed, Export ("textBackgroundBorder", ArgumentSemantic.Strong)]
		YYTextBorder TextBackgroundBorder { get; set; }

		// -(void)setTextBackgroundBorder:(YYTextBorder * _Nullable)textBackgroundBorder range:(NSRange)range;
		[Export ("setTextBackgroundBorder:range:")]
		void SetTextBackgroundBorder ([NullAllowed] YYTextBorder textBackgroundBorder, NSRange range);

		// @property (readwrite, nonatomic) CGAffineTransform textGlyphTransform;
		[Export ("textGlyphTransform", ArgumentSemantic.Assign)]
		CGAffineTransform TextGlyphTransform { get; set; }

		// -(void)setTextGlyphTransform:(CGAffineTransform)textGlyphTransform range:(NSRange)range;
		[Export ("setTextGlyphTransform:range:")]
		void SetTextGlyphTransform (CGAffineTransform textGlyphTransform, NSRange range);

		// -(void)setSuperscript:(NSNumber * _Nullable)superscript range:(NSRange)range;
		[Export ("setSuperscript:range:")]
		void SetSuperscript ([NullAllowed] NSNumber superscript, NSRange range);

		// -(void)setGlyphInfo:(CTGlyphInfoRef _Nullable)glyphInfo range:(NSRange)range;
		[Export ("setGlyphInfo:range:")]
		unsafe void SetGlyphInfo ([NullAllowed] CTGlyphInfoRef* glyphInfo, NSRange range);

		// -(void)setCharacterShape:(NSNumber * _Nullable)characterShape range:(NSRange)range;
		[Export ("setCharacterShape:range:")]
		void SetCharacterShape ([NullAllowed] NSNumber characterShape, NSRange range);

		// -(void)setRunDelegate:(CTRunDelegateRef _Nullable)runDelegate range:(NSRange)range;
		[Export ("setRunDelegate:range:")]
		unsafe void SetRunDelegate ([NullAllowed] CTRunDelegateRef* runDelegate, NSRange range);

		// -(void)setBaselineClass:(CFStringRef _Nullable)baselineClass range:(NSRange)range;
		[Export ("setBaselineClass:range:")]
		unsafe void SetBaselineClass ([NullAllowed] CFStringRef* baselineClass, NSRange range);

		// -(void)setBaselineInfo:(CFDictionaryRef _Nullable)baselineInfo range:(NSRange)range;
		[Export ("setBaselineInfo:range:")]
		unsafe void SetBaselineInfo ([NullAllowed] CFDictionaryRef* baselineInfo, NSRange range);

		// -(void)setBaselineReferenceInfo:(CFDictionaryRef _Nullable)referenceInfo range:(NSRange)range;
		[Export ("setBaselineReferenceInfo:range:")]
		unsafe void SetBaselineReferenceInfo ([NullAllowed] CFDictionaryRef* referenceInfo, NSRange range);

		// -(void)setRubyAnnotation:(CTRubyAnnotationRef _Nullable)ruby range:(NSRange)range __attribute__((availability(ios, introduced=8_0)));
		[iOS (8,0)]
		[Export ("setRubyAnnotation:range:")]
		unsafe void SetRubyAnnotation ([NullAllowed] CTRubyAnnotationRef* ruby, NSRange range);

		// -(void)setAttachment:(NSTextAttachment * _Nullable)attachment range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setAttachment:range:")]
		void SetAttachment ([NullAllowed] NSTextAttachment attachment, NSRange range);

		// -(void)setLink:(id _Nullable)link range:(NSRange)range __attribute__((availability(ios, introduced=7_0)));
		[iOS (7,0)]
		[Export ("setLink:range:")]
		void SetLink ([NullAllowed] NSObject link, NSRange range);

		// -(void)setTextBackedString:(YYTextBackedString * _Nullable)textBackedString range:(NSRange)range;
		[Export ("setTextBackedString:range:")]
		void SetTextBackedString ([NullAllowed] YYTextBackedString textBackedString, NSRange range);

		// -(void)setTextBinding:(YYTextBinding * _Nullable)textBinding range:(NSRange)range;
		[Export ("setTextBinding:range:")]
		void SetTextBinding ([NullAllowed] YYTextBinding textBinding, NSRange range);

		// -(void)setTextAttachment:(YYTextAttachment * _Nullable)textAttachment range:(NSRange)range;
		[Export ("setTextAttachment:range:")]
		void SetTextAttachment ([NullAllowed] YYTextAttachment textAttachment, NSRange range);

		// -(void)setTextHighlight:(YYTextHighlight * _Nullable)textHighlight range:(NSRange)range;
		[Export ("setTextHighlight:range:")]
		void SetTextHighlight ([NullAllowed] YYTextHighlight textHighlight, NSRange range);

		// -(void)setTextBlockBorder:(YYTextBorder * _Nullable)textBlockBorder range:(NSRange)range;
		[Export ("setTextBlockBorder:range:")]
		void SetTextBlockBorder ([NullAllowed] YYTextBorder textBlockBorder, NSRange range);

		// -(void)setTextRubyAnnotation:(id)ruby range:(NSRange)range __attribute__((availability(ios, introduced=8_0)));
		[iOS (8,0)]
		[Export ("setTextRubyAnnotation:range:")]
		void SetTextRubyAnnotation (NSObject ruby, NSRange range);

		// -(void)setTextHighlightRange:(NSRange)range color:(UIColor * _Nullable)color backgroundColor:(UIColor * _Nullable)backgroundColor userInfo:(NSDictionary * _Nullable)userInfo tapAction:(YYTextAction _Nullable)tapAction longPressAction:(YYTextAction _Nullable)longPressAction;
		[Export ("setTextHighlightRange:color:backgroundColor:userInfo:tapAction:longPressAction:")]
		void SetTextHighlightRange (NSRange range, [NullAllowed] UIColor color, [NullAllowed] UIColor backgroundColor, [NullAllowed] NSDictionary userInfo, [NullAllowed] YYTextAction tapAction, [NullAllowed] YYTextAction longPressAction);

		// -(void)setTextHighlightRange:(NSRange)range color:(UIColor * _Nullable)color backgroundColor:(UIColor * _Nullable)backgroundColor tapAction:(YYTextAction _Nullable)tapAction;
		[Export ("setTextHighlightRange:color:backgroundColor:tapAction:")]
		void SetTextHighlightRange (NSRange range, [NullAllowed] UIColor color, [NullAllowed] UIColor backgroundColor, [NullAllowed] YYTextAction tapAction);

		// -(void)setTextHighlightRange:(NSRange)range color:(UIColor * _Nullable)color backgroundColor:(UIColor * _Nullable)backgroundColor userInfo:(NSDictionary * _Nullable)userInfo;
		[Export ("setTextHighlightRange:color:backgroundColor:userInfo:")]
		void SetTextHighlightRange (NSRange range, [NullAllowed] UIColor color, [NullAllowed] UIColor backgroundColor, [NullAllowed] NSDictionary userInfo);

		// -(void)insertString:(NSString * _Nonnull)string atIndex:(NSUInteger)location;
		[Export ("insertString:atIndex:")]
		void InsertString (string @string, nuint location);

		// -(void)appendString:(NSString * _Nonnull)string;
		[Export ("appendString:")]
		void AppendString (string @string);

		// -(void)setClearColorToJoinedEmoji;
		[Export ("setClearColorToJoinedEmoji")]
		void SetClearColorToJoinedEmoji ();

		// -(void)removeDiscontinuousAttributesInRange:(NSRange)range;
		[Export ("removeDiscontinuousAttributesInRange:")]
		void RemoveDiscontinuousAttributesInRange (NSRange range);

		// +(NSArray<NSString *> * _Nonnull)allDiscontinuousAttributeKeys;
		[Static]
		[Export ("allDiscontinuousAttributeKeys")]
		[Verify (MethodToProperty)]
		string[] AllDiscontinuousAttributeKeys { get; }
	}

	// @interface NSAttributedStringYYText : NSObject
	[BaseType (typeof(NSObject))]
	interface NSAttributedStringYYText
	{
		// +(NSMutableAttributedString *)attachmentStringWithContent:(id _Nullable)content contentMode:(UIViewContentMode)contentMode attachmentSize:(CGSize)attachmentSize alignToFont:(UIFont *)font alignment:(YYTextVerticalAlignment)alignment;
		[Static]
		[Export ("attachmentStringWithContent:contentMode:attachmentSize:alignToFont:alignment:")]
		NSMutableAttributedString AttachmentStringWithContent ([NullAllowed] NSObject content, UIViewContentMode contentMode, CGSize attachmentSize, UIFont font, YYTextVerticalAlignment alignment);
	}

	// typedef void (^YYWebImageProgressBlock)(NSInteger, NSInteger);
	delegate void YYWebImageProgressBlock (nint arg0, nint arg1);

	// typedef UIImage * _Nullable (^YYWebImageTransformBlock)(UIImage * _Nonnull, NSURL * _Nonnull);
	delegate UIImage YYWebImageTransformBlock (UIImage arg0, NSUrl arg1);

	// typedef void (^YYWebImageCompletionBlock)(UIImage * _Nullable, NSURL * _Nonnull, YYWebImageFromType, YYWebImageStage, NSError * _Nullable);
	delegate void YYWebImageCompletionBlock ([NullAllowed] UIImage arg0, NSUrl arg1, YYWebImageFromType arg2, YYWebImageStage arg3, [NullAllowed] NSError arg4);

	// @interface YYWebImageManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface YYWebImageManager
	{
		// +(instancetype _Nonnull)sharedManager;
		[Static]
		[Export ("sharedManager")]
		YYWebImageManager SharedManager ();

		// -(instancetype _Nonnull)initWithCache:(id)cache queue:(NSOperationQueue * _Nullable)queue __attribute__((objc_designated_initializer));
		[Export ("initWithCache:queue:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSObject cache, [NullAllowed] NSOperationQueue queue);

		// -(YYWebImageOperation * _Nullable)requestImageWithURL:(NSURL * _Nonnull)url options:(YYWebImageOptions)options progress:(YYWebImageProgressBlock _Nullable)progress transform:(YYWebImageTransformBlock _Nullable)transform completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("requestImageWithURL:options:progress:transform:completion:")]
		[return: NullAllowed]
		YYWebImageOperation RequestImageWithURL (NSUrl url, YYWebImageOptions options, [NullAllowed] YYWebImageProgressBlock progress, [NullAllowed] YYWebImageTransformBlock transform, [NullAllowed] YYWebImageCompletionBlock completion);

		// @property (nonatomic, strong) int * _Nullable cache;
		[NullAllowed, Export ("cache", ArgumentSemantic.Strong)]
		unsafe int* Cache { get; set; }

		// @property (nonatomic, strong) NSOperationQueue * _Nullable queue;
		[NullAllowed, Export ("queue", ArgumentSemantic.Strong)]
		NSOperationQueue Queue { get; set; }

		// @property (copy, nonatomic) YYWebImageTransformBlock _Nullable sharedTransformBlock;
		[NullAllowed, Export ("sharedTransformBlock", ArgumentSemantic.Copy)]
		YYWebImageTransformBlock SharedTransformBlock { get; set; }

		// @property (nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable headers;
		[NullAllowed, Export ("headers", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Headers { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nonnull (^ _Nullable)(NSURL * _Nonnull, NSDictionary<NSString *,NSString *> * _Nullable) headersFilter;
		[NullAllowed, Export ("headersFilter", ArgumentSemantic.Copy)]
		Func<NSURL, NSDictionary<NSString, NSString>, NSDictionary<NSString, NSString>> HeadersFilter { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull (^ _Nullable)(NSURL * _Nonnull) cacheKeyFilter;
		[NullAllowed, Export ("cacheKeyFilter", ArgumentSemantic.Copy)]
		Func<NSURL, NSString> CacheKeyFilter { get; set; }

		// -(NSDictionary<NSString *,NSString *> * _Nullable)headersForURL:(NSURL * _Nonnull)url;
		[Export ("headersForURL:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSString> HeadersForURL (NSUrl url);

		// -(NSString * _Nonnull)cacheKeyForURL:(NSURL * _Nonnull)url;
		[Export ("cacheKeyForURL:")]
		string CacheKeyForURL (NSUrl url);
	}

	// @interface YYWebImage (UIImageView)
	[Category]
	[BaseType (typeof(UIImageView))]
	interface UIImageView_YYWebImage
	{
		// @property (nonatomic, strong) NSURL * _Nullable imageURL;
		[NullAllowed, Export ("imageURL", ArgumentSemantic.Strong)]
		NSUrl ImageURL { get; set; }

		// -(void)setImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder;
		[Export ("setImageWithURL:placeholder:")]
		void SetImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder);

		// -(void)setImageWithURL:(NSURL * _Nullable)imageURL options:(YYWebImageOptions)options;
		[Export ("setImageWithURL:options:")]
		void SetImageWithURL ([NullAllowed] NSUrl imageURL, YYWebImageOptions options);

		// -(void)setImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setImageWithURL:placeholder:options:completion:")]
		void SetImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)setImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options progress:(YYWebImageProgressBlock _Nullable)progress transform:(YYWebImageTransformBlock _Nullable)transform completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setImageWithURL:placeholder:options:progress:transform:completion:")]
		void SetImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageProgressBlock progress, [NullAllowed] YYWebImageTransformBlock transform, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)setImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options manager:(YYWebImageManager * _Nullable)manager progress:(YYWebImageProgressBlock _Nullable)progress transform:(YYWebImageTransformBlock _Nullable)transform completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setImageWithURL:placeholder:options:manager:progress:transform:completion:")]
		void SetImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageManager manager, [NullAllowed] YYWebImageProgressBlock progress, [NullAllowed] YYWebImageTransformBlock transform, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)cancelCurrentImageRequest;
		[Export ("cancelCurrentImageRequest")]
		void CancelCurrentImageRequest ();

		// @property (nonatomic, strong) NSURL * _Nullable highlightedImageURL;
		[NullAllowed, Export ("highlightedImageURL", ArgumentSemantic.Strong)]
		NSUrl HighlightedImageURL { get; set; }

		// -(void)setHighlightedImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder;
		[Export ("setHighlightedImageWithURL:placeholder:")]
		void SetHighlightedImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder);

		// -(void)setHighlightedImageWithURL:(NSURL * _Nullable)imageURL options:(YYWebImageOptions)options;
		[Export ("setHighlightedImageWithURL:options:")]
		void SetHighlightedImageWithURL ([NullAllowed] NSUrl imageURL, YYWebImageOptions options);

		// -(void)setHighlightedImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setHighlightedImageWithURL:placeholder:options:completion:")]
		void SetHighlightedImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)setHighlightedImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options progress:(YYWebImageProgressBlock _Nullable)progress transform:(YYWebImageTransformBlock _Nullable)transform completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setHighlightedImageWithURL:placeholder:options:progress:transform:completion:")]
		void SetHighlightedImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageProgressBlock progress, [NullAllowed] YYWebImageTransformBlock transform, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)setHighlightedImageWithURL:(NSURL * _Nullable)imageURL placeholder:(UIImage * _Nullable)placeholder options:(YYWebImageOptions)options manager:(YYWebImageManager * _Nullable)manager progress:(YYWebImageProgressBlock _Nullable)progress transform:(YYWebImageTransformBlock _Nullable)transform completion:(YYWebImageCompletionBlock _Nullable)completion;
		[Export ("setHighlightedImageWithURL:placeholder:options:manager:progress:transform:completion:")]
		void SetHighlightedImageWithURL ([NullAllowed] NSUrl imageURL, [NullAllowed] UIImage placeholder, YYWebImageOptions options, [NullAllowed] YYWebImageManager manager, [NullAllowed] YYWebImageProgressBlock progress, [NullAllowed] YYWebImageTransformBlock transform, [NullAllowed] YYWebImageCompletionBlock completion);

		// -(void)cancelCurrentHighlightedImageRequest;
		[Export ("cancelCurrentHighlightedImageRequest")]
		void CancelCurrentHighlightedImageRequest ();
	}

	// @interface YYAnimatedImageView : UIImageView
	[BaseType (typeof(UIImageView))]
	interface YYAnimatedImageView
	{
		// @property (nonatomic) BOOL autoPlayAnimatedImage;
		[Export ("autoPlayAnimatedImage")]
		bool AutoPlayAnimatedImage { get; set; }

		// @property (nonatomic) NSUInteger currentAnimatedImageIndex;
		[Export ("currentAnimatedImageIndex")]
		nuint CurrentAnimatedImageIndex { get; set; }

		// @property (readonly, nonatomic) BOOL currentIsPlayingAnimation;
		[Export ("currentIsPlayingAnimation")]
		bool CurrentIsPlayingAnimation { get; }

		// @property (copy, nonatomic) NSString * _Nonnull runloopMode;
		[Export ("runloopMode")]
		string RunloopMode { get; set; }

		// @property (nonatomic) NSUInteger maxBufferSize;
		[Export ("maxBufferSize")]
		nuint MaxBufferSize { get; set; }
	}

	// @protocol YYAnimatedImage <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YYAnimatedImage
	{
		// @required -(NSUInteger)animatedImageFrameCount;
		[Abstract]
		[Export ("animatedImageFrameCount")]
		[Verify (MethodToProperty)]
		nuint AnimatedImageFrameCount { get; }

		// @required -(NSUInteger)animatedImageLoopCount;
		[Abstract]
		[Export ("animatedImageLoopCount")]
		[Verify (MethodToProperty)]
		nuint AnimatedImageLoopCount { get; }

		// @required -(NSUInteger)animatedImageBytesPerFrame;
		[Abstract]
		[Export ("animatedImageBytesPerFrame")]
		[Verify (MethodToProperty)]
		nuint AnimatedImageBytesPerFrame { get; }

		// @required -(UIImage * _Nullable)animatedImageFrameAtIndex:(NSUInteger)index;
		[Abstract]
		[Export ("animatedImageFrameAtIndex:")]
		[return: NullAllowed]
		UIImage AnimatedImageFrameAtIndex (nuint index);

		// @required -(NSTimeInterval)animatedImageDurationAtIndex:(NSUInteger)index;
		[Abstract]
		[Export ("animatedImageDurationAtIndex:")]
		double AnimatedImageDurationAtIndex (nuint index);

		// @optional -(CGRect)animatedImageContentsRectAtIndex:(NSUInteger)index;
		[Export ("animatedImageContentsRectAtIndex:")]
		CGRect AnimatedImageContentsRectAtIndex (nuint index);
	}

	// @interface YYLabel : UIView <NSCoding>
	[BaseType (typeof(UIView))]
	interface YYLabel : INSCoding
	{
		// @property (copy, nonatomic) NSString * _Nullable text;
		[NullAllowed, Export ("text")]
		string Text { get; set; }

		// @property (nonatomic, strong) UIFont * _Null_unspecified font;
		[Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Null_unspecified textColor;
		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable shadowColor;
		[NullAllowed, Export ("shadowColor", ArgumentSemantic.Strong)]
		UIColor ShadowColor { get; set; }

		// @property (nonatomic) CGSize shadowOffset;
		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		CGSize ShadowOffset { get; set; }

		// @property (nonatomic) CGFloat shadowBlurRadius;
		[Export ("shadowBlurRadius")]
		nfloat ShadowBlurRadius { get; set; }

		// @property (nonatomic) NSTextAlignment textAlignment;
		[Export ("textAlignment", ArgumentSemantic.Assign)]
		NSTextAlignment TextAlignment { get; set; }

		// @property (nonatomic) YYTextVerticalAlignment textVerticalAlignment;
		[Export ("textVerticalAlignment", ArgumentSemantic.Assign)]
		YYTextVerticalAlignment TextVerticalAlignment { get; set; }

		// @property (copy, nonatomic) NSAttributedString * _Nullable attributedText;
		[NullAllowed, Export ("attributedText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedText { get; set; }

		// @property (nonatomic) NSLineBreakMode lineBreakMode;
		[Export ("lineBreakMode", ArgumentSemantic.Assign)]
		NSLineBreakMode LineBreakMode { get; set; }

		// @property (copy, nonatomic) NSAttributedString * _Nullable truncationToken;
		[NullAllowed, Export ("truncationToken", ArgumentSemantic.Copy)]
		NSAttributedString TruncationToken { get; set; }

		// @property (nonatomic) NSUInteger numberOfLines;
		[Export ("numberOfLines")]
		nuint NumberOfLines { get; set; }

		// @property (nonatomic, strong) id _Nullable textParser;
		[NullAllowed, Export ("textParser", ArgumentSemantic.Strong)]
		NSObject TextParser { get; set; }

		// @property (nonatomic, strong) int * _Nullable textLayout;
		[NullAllowed, Export ("textLayout", ArgumentSemantic.Strong)]
		unsafe int* TextLayout { get; set; }

		// @property (copy, nonatomic) UIBezierPath * _Nullable textContainerPath;
		[NullAllowed, Export ("textContainerPath", ArgumentSemantic.Copy)]
		UIBezierPath TextContainerPath { get; set; }

		// @property (copy, nonatomic) NSArray<UIBezierPath *> * _Nullable exclusionPaths;
		[NullAllowed, Export ("exclusionPaths", ArgumentSemantic.Copy)]
		UIBezierPath[] ExclusionPaths { get; set; }

		// @property (nonatomic) UIEdgeInsets textContainerInset;
		[Export ("textContainerInset", ArgumentSemantic.Assign)]
		UIEdgeInsets TextContainerInset { get; set; }

		// @property (getter = isVerticalForm, nonatomic) BOOL verticalForm;
		[Export ("verticalForm")]
		bool VerticalForm { [Bind ("isVerticalForm")] get; set; }

		// @property (copy, nonatomic) id _Nullable linePositionModifier;
		[NullAllowed, Export ("linePositionModifier", ArgumentSemantic.Copy)]
		NSObject LinePositionModifier { get; set; }

		// @property (copy, nonatomic) int * _Nullable debugOption;
		[NullAllowed, Export ("debugOption", ArgumentSemantic.Copy)]
		unsafe int* DebugOption { get; set; }

		// @property (nonatomic) CGFloat preferredMaxLayoutWidth;
		[Export ("preferredMaxLayoutWidth")]
		nfloat PreferredMaxLayoutWidth { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable textTapAction;
		[NullAllowed, Export ("textTapAction", ArgumentSemantic.Copy)]
		YYTextAction TextTapAction { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable textLongPressAction;
		[NullAllowed, Export ("textLongPressAction", ArgumentSemantic.Copy)]
		YYTextAction TextLongPressAction { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable highlightTapAction;
		[NullAllowed, Export ("highlightTapAction", ArgumentSemantic.Copy)]
		YYTextAction HighlightTapAction { get; set; }

		// @property (copy, nonatomic) YYTextAction _Nullable highlightLongPressAction;
		[NullAllowed, Export ("highlightLongPressAction", ArgumentSemantic.Copy)]
		YYTextAction HighlightLongPressAction { get; set; }

		// @property (nonatomic) BOOL displaysAsynchronously;
		[Export ("displaysAsynchronously")]
		bool DisplaysAsynchronously { get; set; }

		// @property (nonatomic) BOOL clearContentsBeforeAsynchronouslyDisplay;
		[Export ("clearContentsBeforeAsynchronouslyDisplay")]
		bool ClearContentsBeforeAsynchronouslyDisplay { get; set; }

		// @property (nonatomic) BOOL fadeOnAsynchronouslyDisplay;
		[Export ("fadeOnAsynchronouslyDisplay")]
		bool FadeOnAsynchronouslyDisplay { get; set; }

		// @property (nonatomic) BOOL fadeOnHighlight;
		[Export ("fadeOnHighlight")]
		bool FadeOnHighlight { get; set; }

		// @property (nonatomic) BOOL ignoreCommonProperties;
		[Export ("ignoreCommonProperties")]
		bool IgnoreCommonProperties { get; set; }
	}

	// @protocol YYTextViewDelegate <NSObject, UIScrollViewDelegate>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface YYTextViewDelegate : IUIScrollViewDelegate
	{
		// @optional -(BOOL)textViewShouldBeginEditing:(YYTextView * _Nonnull)textView;
		[Export ("textViewShouldBeginEditing:")]
		bool TextViewShouldBeginEditing (YYTextView textView);

		// @optional -(BOOL)textViewShouldEndEditing:(YYTextView * _Nonnull)textView;
		[Export ("textViewShouldEndEditing:")]
		bool TextViewShouldEndEditing (YYTextView textView);

		// @optional -(void)textViewDidBeginEditing:(YYTextView * _Nonnull)textView;
		[Export ("textViewDidBeginEditing:")]
		void TextViewDidBeginEditing (YYTextView textView);

		// @optional -(void)textViewDidEndEditing:(YYTextView * _Nonnull)textView;
		[Export ("textViewDidEndEditing:")]
		void TextViewDidEndEditing (YYTextView textView);

		// @optional -(BOOL)textView:(YYTextView * _Nonnull)textView shouldChangeTextInRange:(NSRange)range replacementText:(NSString * _Nonnull)text;
		[Export ("textView:shouldChangeTextInRange:replacementText:")]
		bool TextView (YYTextView textView, NSRange range, string text);

		// @optional -(void)textViewDidChange:(YYTextView * _Nonnull)textView;
		[Export ("textViewDidChange:")]
		void TextViewDidChange (YYTextView textView);

		// @optional -(void)textViewDidChangeSelection:(YYTextView * _Nonnull)textView;
		[Export ("textViewDidChangeSelection:")]
		void TextViewDidChangeSelection (YYTextView textView);

		// @optional -(BOOL)textView:(YYTextView * _Nonnull)textView shouldTapHighlight:(YYTextHighlight * _Nonnull)highlight inRange:(NSRange)characterRange;
		[Export ("textView:shouldTapHighlight:inRange:")]
		bool TextView (YYTextView textView, YYTextHighlight highlight, NSRange characterRange);

		// @optional -(void)textView:(YYTextView * _Nonnull)textView didTapHighlight:(YYTextHighlight * _Nonnull)highlight inRange:(NSRange)characterRange rect:(CGRect)rect;
		[Export ("textView:didTapHighlight:inRange:rect:")]
		void TextView (YYTextView textView, YYTextHighlight highlight, NSRange characterRange, CGRect rect);

		// @optional -(BOOL)textView:(YYTextView * _Nonnull)textView shouldLongPressHighlight:(YYTextHighlight * _Nonnull)highlight inRange:(NSRange)characterRange;
		[Export ("textView:shouldLongPressHighlight:inRange:")]
		bool TextView (YYTextView textView, YYTextHighlight highlight, NSRange characterRange);

		// @optional -(void)textView:(YYTextView * _Nonnull)textView didLongPressHighlight:(YYTextHighlight * _Nonnull)highlight inRange:(NSRange)characterRange rect:(CGRect)rect;
		[Export ("textView:didLongPressHighlight:inRange:rect:")]
		void TextView (YYTextView textView, YYTextHighlight highlight, NSRange characterRange, CGRect rect);
	}

	// @interface YYTextView : UIScrollView <UITextInput>
	[BaseType (typeof(UIScrollView))]
	interface YYTextView : IUITextInput
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		YYTextViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<YYTextViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * _Null_unspecified text;
		[Export ("text")]
		string Text { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable font;
		[NullAllowed, Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable textColor;
		[NullAllowed, Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic) NSTextAlignment textAlignment;
		[Export ("textAlignment", ArgumentSemantic.Assign)]
		NSTextAlignment TextAlignment { get; set; }

		// @property (nonatomic) YYTextVerticalAlignment textVerticalAlignment;
		[Export ("textVerticalAlignment", ArgumentSemantic.Assign)]
		YYTextVerticalAlignment TextVerticalAlignment { get; set; }

		// @property (nonatomic) UIDataDetectorTypes dataDetectorTypes;
		[Export ("dataDetectorTypes", ArgumentSemantic.Assign)]
		UIDataDetectorTypes DataDetectorTypes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable linkTextAttributes;
		[NullAllowed, Export ("linkTextAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> LinkTextAttributes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable highlightTextAttributes;
		[NullAllowed, Export ("highlightTextAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> HighlightTextAttributes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable typingAttributes;
		[NullAllowed, Export ("typingAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TypingAttributes { get; set; }

		// @property (copy, nonatomic) NSAttributedString * _Nullable attributedText;
		[NullAllowed, Export ("attributedText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedText { get; set; }

		// @property (nonatomic, strong) id _Nullable textParser;
		[NullAllowed, Export ("textParser", ArgumentSemantic.Strong)]
		NSObject TextParser { get; set; }

		// @property (readonly, nonatomic, strong) int * _Nullable textLayout;
		[NullAllowed, Export ("textLayout", ArgumentSemantic.Strong)]
		unsafe int* TextLayout { get; }

		// @property (copy, nonatomic) NSString * _Nullable placeholderText;
		[NullAllowed, Export ("placeholderText")]
		string PlaceholderText { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable placeholderFont;
		[NullAllowed, Export ("placeholderFont", ArgumentSemantic.Strong)]
		UIFont PlaceholderFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable placeholderTextColor;
		[NullAllowed, Export ("placeholderTextColor", ArgumentSemantic.Strong)]
		UIColor PlaceholderTextColor { get; set; }

		// @property (copy, nonatomic) NSAttributedString * _Nullable placeholderAttributedText;
		[NullAllowed, Export ("placeholderAttributedText", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedText { get; set; }

		// @property (nonatomic) UIEdgeInsets textContainerInset;
		[Export ("textContainerInset", ArgumentSemantic.Assign)]
		UIEdgeInsets TextContainerInset { get; set; }

		// @property (copy, nonatomic) NSArray<UIBezierPath *> * _Nullable exclusionPaths;
		[NullAllowed, Export ("exclusionPaths", ArgumentSemantic.Copy)]
		UIBezierPath[] ExclusionPaths { get; set; }

		// @property (getter = isVerticalForm, nonatomic) BOOL verticalForm;
		[Export ("verticalForm")]
		bool VerticalForm { [Bind ("isVerticalForm")] get; set; }

		// @property (copy, nonatomic) id _Nullable linePositionModifier;
		[NullAllowed, Export ("linePositionModifier", ArgumentSemantic.Copy)]
		NSObject LinePositionModifier { get; set; }

		// @property (copy, nonatomic) int * _Nullable debugOption;
		[NullAllowed, Export ("debugOption", ArgumentSemantic.Copy)]
		unsafe int* DebugOption { get; set; }

		// -(void)scrollRangeToVisible:(NSRange)range;
		[Export ("scrollRangeToVisible:")]
		void ScrollRangeToVisible (NSRange range);

		// @property (nonatomic) NSRange selectedRange;
		[Export ("selectedRange", ArgumentSemantic.Assign)]
		NSRange SelectedRange { get; set; }

		// @property (nonatomic) BOOL clearsOnInsertion;
		[Export ("clearsOnInsertion")]
		bool ClearsOnInsertion { get; set; }

		// @property (getter = isSelectable, nonatomic) BOOL selectable;
		[Export ("selectable")]
		bool Selectable { [Bind ("isSelectable")] get; set; }

		// @property (getter = isHighlightable, nonatomic) BOOL highlightable;
		[Export ("highlightable")]
		bool Highlightable { [Bind ("isHighlightable")] get; set; }

		// @property (getter = isEditable, nonatomic) BOOL editable;
		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		// @property (nonatomic) BOOL allowsPasteImage;
		[Export ("allowsPasteImage")]
		bool AllowsPasteImage { get; set; }

		// @property (nonatomic) BOOL allowsPasteAttributedString;
		[Export ("allowsPasteAttributedString")]
		bool AllowsPasteAttributedString { get; set; }

		// @property (nonatomic) BOOL allowsCopyAttributedString;
		[Export ("allowsCopyAttributedString")]
		bool AllowsCopyAttributedString { get; set; }

		// @property (nonatomic) BOOL allowsUndoAndRedo;
		[Export ("allowsUndoAndRedo")]
		bool AllowsUndoAndRedo { get; set; }

		// @property (nonatomic) NSUInteger maximumUndoLevel;
		[Export ("maximumUndoLevel")]
		nuint MaximumUndoLevel { get; set; }

		// @property (readwrite, nonatomic, strong) __kindof UIView * _Nullable inputView;
		[Export ("inputView", ArgumentSemantic.Strong)]
		UIView InputView { get; set; }

		// @property (readwrite, nonatomic, strong) __kindof UIView * _Nullable inputAccessoryView;
		[Export ("inputAccessoryView", ArgumentSemantic.Strong)]
		UIView InputAccessoryView { get; set; }

		// @property (nonatomic) CGFloat extraAccessoryViewHeight;
		[Export ("extraAccessoryViewHeight")]
		nfloat ExtraAccessoryViewHeight { get; set; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull YYTextViewTextDidBeginEditingNotification __attribute__((visibility("default")));
		[Field ("YYTextViewTextDidBeginEditingNotification", "__Internal")]
		NSString YYTextViewTextDidBeginEditingNotification { get; }

		// extern NSString *const _Nonnull YYTextViewTextDidChangeNotification __attribute__((visibility("default")));
		[Field ("YYTextViewTextDidChangeNotification", "__Internal")]
		NSString YYTextViewTextDidChangeNotification { get; }

		// extern NSString *const _Nonnull YYTextViewTextDidEndEditingNotification __attribute__((visibility("default")));
		[Field ("YYTextViewTextDidEndEditingNotification", "__Internal")]
		NSString YYTextViewTextDidEndEditingNotification { get; }
	}
}
