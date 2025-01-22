<script lang="ts" setup>
import { ref, h, nextTick, reactive, onBeforeMount } from "vue";
import {
  VxeFormInstance,
  VxeFormPropTypes,
  VxeInput,
  VxeSelect
} from "vxe-pc-ui";
import { ReDictionary } from "@/components/ReDictionary";
import { getSingle, submitData } from "@/api/asset/assetList";
import { getPageList } from "@/api/system/user";

const emits = defineEmits<{ (e: "reload"): void }>();
const vxeModalRef = ref();
const modalOptions = reactive<{
  modalValue: boolean;
  modalTitle: string;
  canSubmit: boolean;
}>({
  modalValue: false,
  modalTitle: "",
  canSubmit: true
});

const showModal = (title: string, canSubmit?: boolean): void => {
  modalOptions.modalTitle = title;
  modalOptions.modalValue = true;
  modalOptions.canSubmit = canSubmit ?? true;
};

interface AddAssetInput {
  assetId: string;
  assetType: number | null;
  assetBrand: string;
  assetModel: string;
  assetSeries: string;
  serverTag: string;
  assignUser: number | null;
  warranty: number | null;
  purchaseDate: string;
  remark: string;
  assetName: string;
  assetStatus: number | null;
  lastUser: number | null;
}
const formRef = ref<VxeFormInstance>();
const defaultFormData = () => {
  return {
    assetId: "",
    assetType: null,
    assetBrand: "",
    assetModel: "",
    assetSeries: "",
    serverTag: "",
    assignUser: null,
    warranty: null,
    purchaseDate: "",
    remark: "",
    assetName: "",
    assetStatus: null,
    lastUser: null
  };
};
const assetUserOptions = ref<any[]>([]);
const formData = ref<AddAssetInput>(defaultFormData());
const formItems = ref<VxeFormPropTypes.Items>([
  {
    field: "assetId",
    title: "资产编号",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输入资产编号" }
    }
  },
  {
    field: "assetName",
    title: "资产名称",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输入资产名称" }
    }
  },
  {
    field: "assetType",
    title: "资产类型",
    span: 24,
    slots: {
      default: ({ data }) => {
        return h(ReDictionary, {
          code: "dict_asset_type",
          modelValue: data.assetType,
          placeholder: "请选择资产类型",
          onChange({ value }) {
            data.assetType = value;
            formData.value.assetType = value;
          }
        });
      }
    }
  },
  {
    field: "assetBrand",
    title: "品牌",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输入资产品牌" }
    }
  },
  {
    field: "assetModel",
    title: "型号",
    span: 24,
    itemRender: { name: "$input", props: { placeholder: "请输入型号" } }
  },
  {
    field: "assetSeries",
    title: "系列",
    span: 24,
    itemRender: { name: "$input", props: { placeholder: "请输入系列" } }
  },
  {
    field: "serverTag",
    title: "ST",
    span: 24,
    itemRender: { name: "$input", props: { placeholder: "请输入ST" } }
  },
  {
    field: "assignUser",
    title: "分配用户",
    span: 24,
    slots: {
      default: ({ data }) => [
        h(VxeSelect, {
          options: assetUserOptions.value,
          filterable: true, //启动搜索
          optionProps: {
            value: "value",
            label: "label"
          },
          placeholder: "请选择分配用户",
          modelValue: data.assignUser,
          "onUpdate:modelValue": v => {
            data.assignUser = v?.toString(); // 确保选中状态值的更新
            formData.value.assignUser = v;
          }
        })
      ]
    }
  },
  {
    field: "assetStatus",
    title: "资产状态",
    span: 24,
    slots: {
      default: ({ data }) => [
        h(VxeSelect, {
          options: [
            { label: "报废", value: "0" },
            { label: "闲置", value: "1" },
            { label: "使用中", value: "2" },
            { label: "出售", value: "3" }
          ],
          filterable: true,
          optionProps: {
            value: "value", // 确保 value 绑定到状态值
            label: "label" // 确保 label 正确显示标签
          },
          placeholder: "请选择资产状态",
          modelValue: data.assetStatus?.toString(), // 确保 modelValue 正确绑定到数据
          "onUpdate:modelValue": v => {
            data.assetStatus = v?.toString(); // 确保选中状态值的更新
          }
        })
      ]
    }
  },
  {
    field: "warranty",
    title: "质保期",
    span: 24,
    itemRender: {
      name: "$input",
      props: { type: "number", placeholder: "请输入质保周期" }
    }
  },
  {
    field: "purchaseDate",
    title: "购买日期",
    span: 24,
    slots: {
      default: ({ data }) => [
        h(VxeInput, {
          type: "date",
          format: "yyyy-MM-dd",
          valueFormat: "yyyy-MM-dd", // 指定返回的日期格式
          placeholder: "请选择购买日期",
          modelValue: data.purchaseDate,
          clearable: true, // 允许清除日期
          "onUpdate:modelValue": (value: string) => {
            data.purchaseDate = value;
            formData.value.purchaseDate = value;
          }
        })
      ]
    }
  },
  {
    field: "lastUser",
    title: "上一位用户",
    span: 24,
    slots: {
      default: ({ data }) => [
        h(VxeSelect, {
          options: assetUserOptions.value,
          filterable: true, //启动搜索
          optionProps: {
            value: "value",
            label: "label"
          },
          placeholder: "请选择上一位用户",
          modelValue: data.lastUser,
          "onUpdate:modelValue": v => {
            //data.id = v.value;
            data.lastUser = v?.toString(); // 确保选中状态值的更新
            formData.value.lastUser = v;
          }
        })
      ]
    }
  },
  {
    field: "remark",
    title: "备注",
    span: 24,
    itemRender: {
      name: "$textarea",
      props: { placeholder: "请输入备注" }
    }
  }
]);
const formRules = ref<VxeFormPropTypes.Rules>({
  assetId: [{ required: true, message: "请输入资产编号" }],
  assetType: [{ required: true, message: "请选择资产类型" }],
  assetStatus: [{ required: true, message: "请选择资产状态" }],
  assetName: [{ required: true, message: "请输入资产名称" }]
});

const showAddModal = () => {
  showModal(`添加资产`);
  debugger;
  formData.value = defaultFormData();
  nextTick(() => {
    formRef.value.clearValidate();
  });
};
const showEditModal = (record: Recordable) => {
  showModal(`编辑资产->${record.assetId}`);
  nextTick(() => {
    formRef.value.clearValidate();
    getSingle(record.id).then((data: any) => {
      formData.value = data;
      //formData.value.assetStatus = data.assetStatus.toString(); // 确保状态为字符串
    });
  });
};
const showViewModal = (record: Recordable) => {
  showModal(`查看资产->${record.assetId}`, false);
  nextTick(() => {
    formRef.value.clearValidate();
    getSingle(record.id).then((data: any) => {
      formData.value = data;
      //formData.value.assetStatus = data.assetStatus.toString(); // 确保状态为字符串
    });
  });
};
const handleSubmit = async () => {
  const validate = await formRef.value.validate();
  if (!validate) {
    submitData(formData.value).then(() => {
      modalOptions.modalValue = false;
      emits("reload");
    });
  }
};
onBeforeMount(() => {
  getPageList({ PageSize: 200 }).then((result: any) => {
    assetUserOptions.value = result.items.map((item: any) => ({
      value: item.id,
      label: item.name
    }));
  });
});

defineExpose({ showAddModal, showEditModal, showViewModal });
</script>
<template>
  <vxe-modal
    ref="vxeModalRef"
    v-model="modalOptions.modalValue"
    width="600"
    height="500"
    showFooter
    :title="modalOptions.modalTitle"
  >
    <template #default>
      <vxe-form
        ref="formRef"
        :data="formData"
        :items="formItems"
        :rules="formRules"
        :titleWidth="100"
        :titleColon="true"
        :titleAlign="`right`"
      />
    </template>
    <template #footer>
      <vxe-button content="关闭" @click="modalOptions.modalValue = false" />
      <vxe-button
        v-if="modalOptions.canSubmit"
        status="primary"
        content="确定"
        @click="handleSubmit"
      />
    </template>
  </vxe-modal>
</template>
